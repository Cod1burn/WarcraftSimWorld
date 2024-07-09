using UnityEngine;
using CombatUnits;
using CombatComp.Spells;

namespace CombatComp.Events
{
    public enum DamageType
    {
        Physical,
        Fire,
        Frost,
        Arcane,
        Shadow,
        Natural,
        Lightning,
        Holy,
        Necrotic,
        Chaos
    }

    public class DamageEvent : CombatEvent
    {
        public Unit Caster;

        public readonly float RawDamage;

        public float damage;

        public DamageType DamageType;

        public string SpellName;

        public int SpellID;
        
        public Unit Target;
        
        public DamageEvent(Unit caster, float damage, DamageType type, string spellName, int spellId, Unit target)
        {
            Type = EventType.DamageEvent;
            RawDamage = damage;
            damage = RawDamage;
            DamageType = type;
            SpellName = spellName;
            SpellID = spellId;
            Target = target;
        }
    }
}