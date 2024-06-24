using System.Collections;
using System.Collections.Generic;
using CombatComp;
using CombatComp.Spells;
using UnityEngine;
using CombatUnits;

namespace CombatComp
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
    
    public class Damage
    {
        public Unit Caster;
        
        public Spell Spell;
        
        public float RawDamage;
        
        public DamageType DamageType;
    }
}
