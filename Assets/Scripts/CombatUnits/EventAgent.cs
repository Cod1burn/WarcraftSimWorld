using WorldOfSim.CombatComp.Events;
using WorldOfSim.CombatComp;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WorldOfSim.CombatUnits{
    public sealed class EventAgent
    {
        Unit _unit;

        List<CombatEvent> _cevents;
        List<CombatEvent> _nextTickEvents;

        public EventAgent(Unit unit)
        {
            _unit = unit;
        }

        public void ProcessEvent(CombatEvent cevent)
        {
            _cevents = _nextTickEvents;
            _nextTickEvents = new List<CombatEvent>();
        }

        public void ReceiveEvent(CombatEvent cevent)
        {
            _nextTickEvents.Add(cevent);
        }

        public void ProcessDamage(DamageEvent cevent)
        {
            cevent.damage *= _unit.dmgTakenMultiplier;
            switch(cevent.DamageType)
            {
                case DamageType.Physical:
                    cevent.damage *= 1 - _unit.physicalResist;
                    break;
                
                case DamageType.Chaos:
                    break;

                default:
                    cevent.damage *= 1 - _unit.magicalResist;
                    break;
            }

            // Damage absorb auras
            foreach(var a in _unit.Auras.Where(a => a.Tags.Contains(AuraTag.DamageAbsorb)))
            {
                cevent = a.OnDamageTaken(cevent);
                if (cevent.damage <= 0)
                    break;
            }
            // If the damage is not fully absorbed, check damage taken trigger auras
            if (cevent.damage > 0)
                cevent = _unit.Auras.Where(a => a.Tags.Contains(AuraTag.DamageTaken)).Aggregate(cevent, (current, a) => a.OnDamageTaken(current));
            
            if (cevent.damage > 0)
                _unit.HealthChange(-cevent.damage);
            
            // Generate Log
            string message = $"{cevent.Caster.unitName} dealt {cevent.damage} ({cevent.RawDamage}) {cevent.DamageType} damage to {_unit.unitName} with {cevent.SpellName}({cevent.SpellID}).";
        }

    }
}