using UnityEngine;
using CombatUnits;

namespace CombatComp.Events
{
    public class DamageEvent : CombatEvent
    {
        public Damage Damage;

        public Unit Target;
        
        public float FinalDamage;
        
        public DamageEvent(Damage damage, Unit target, float finalDamage)
        {
            Type = EventType.DamageEvent;
            Damage = damage;
            Target = target;
            FinalDamage = finalDamage;
        }
        
        public override string EventString()
        {
            return $"{TimeStamp}: {Damage.Caster.unitName} dealt {FinalDamage} ({Damage.RawDamage}) {Damage.DamageType} damage to {Target.unitName} by {Damage.Spell.Name}";
        }
    }
}