using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CombatUnits;

namespace CombatComp
{
    public enum AuraTag
    {
        DoT,
        HoT,
        StatChange,
        SpellModifier,
        DamageTaken,
        DamageDealt,
        DamageAbsorb,
        HealingTaken,
        HealingDealt,
        HealingAbsorb
    }
    
    public class Aura
    {
        public string AuraName;
        
        public bool Buff;
        
        public float Duration;

        public float Timer;

        public float Interval;

        public float TickTimer;

        public Unit Caster;

        public Unit Owner;

        public bool Unique;
        
        public bool Stackable;
        
        public int Stack;

        public int MaxStacks;
        
        public Dictionary<string, float> Values;

        public bool Expired;

        public List<AuraTag> Tags;

        public Aura()
        {
            Values = new Dictionary<string, float>();
            Tags = new List<AuraTag>();
        }
        
        public virtual void OnApply(Unit caster, Unit owner)
        {
            caster = caster;
            owner = owner;
            Timer = 0.0f;
            TickTimer = 0.0f;
            Expired = false;
        }

        public virtual void Update(float deltaTime)
        {
            Timer += deltaTime;
            TickTimer += deltaTime;
            if (TickTimer >= Interval)
            {
                OnTick();
                TickTimer -= Interval;
            }
            if (Timer >= Duration)
            {
                OnExpire();
            }
        }

        // For effect such as damage over time or healing over time
        public virtual void OnTick()
        {
            
        }
        
        public virtual Damage OnTakeDamage(Damage damage)
        {
            return damage;
        }
        
        public virtual Damage OnDealDamage(Damage damage)
        {
            return damage;
        }
        

        // For effect such as stat increase or decrease
        public virtual void OnExpire()
        {
            Expired = true;
        }
    }
}
