using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CombatUnits;

namespace CombatComp
{
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

        public int ValueNum;

        public float[] Values;

        public bool Expired;

        public Aura()
        {
            
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

        // For effect such as stat increase or decrease
        public virtual void OnExpire()
        {
            Expired = true;
        }
    }
}
