using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CombatComp;
using CombatComp.Events;
using CombatComp.Spells;
using UnityEngine;

namespace CombatUnits
{
    public class Unit : MonoBehaviour
    {
        public string unitName;
        
        // Primary Stats
        public float health;

        public float maxHealth;

        public float healthRegen;
        
        public float resource;

        public float maxResource;

        public float resourceRegen;

        public string resourceType;

        public float armor;

        public float armorKValue;
        
        public float armorMultiplier;

        public float physicalResist => 1.0f - armor * armorMultiplier / ( armor * armorMultiplier + armorKValue);

        public float magicalResist;
        
        public float dmgTakenMultiplier;
        
        public float dmgDealtMultiplier;
        
        // AP = Attack Power
        public float ap;
        
        public float apMultiplier;
        
        // SP = Spell Power
        public float sp;
        
        public float spMultiplier;
        
        // Sub Stats
        public float crit;

        public float haste;
        
        public float mastery;

        public float versat;
        
        // Weapon Stats
        public bool isMelee;

        public float mainHandDmg;
        
        public float mainHandInterval;
        
        public float mainHandSpeed;

        public float mainHandTimer;
        
        public float offHandDmg;

        public float offHandInterval;

        public float offHandSpeed;

        public float offHandTimer;
        
        // Condition
        public List<Aura> Auras;

        public Unit unitTarget;
        
        // Spells
        public List<int> SpellBook;
        
        public int CastingSpell;

        public float castTimer;
        
        public float globalCooldown;
        
        public float gcdTimer;

        // CombatEvents
        public EventAgent agent {get; private set;}
        
        // Start is called before the first frame update
        protected void Awake()
        {
            Auras = new List<Aura>();
            SpellBook = new List<int>();
            agent = new EventAgent(this);
        }

        // Update is called once per frame
        protected void FixedUpdate()
        {
            // Spell Casting
            if(CastingSpell > 0)
            {
            }

            // Auto Attack Timer
            if (isMelee)
            {
                if (mainHandTimer > 0.0f) mainHandTimer -= Time.deltaTime;
                if (offHandTimer > 0.0f) offHandTimer -= Time.deltaTime;
            }

            // Spell Cooldowns
            
            
            // Global Cooldown
            if (gcdTimer > 0.0f) gcdTimer -= Time.deltaTime;
            
            // Regeneration
            health = Math.Clamp(health + healthRegen * Time.deltaTime, 0.0f, maxHealth);
            resource = Math.Clamp(resource + resourceRegen * Time.deltaTime, 0.0f, maxResource);
            
            // Aura Updates
            foreach (Aura aura in Auras)
            {
                if (aura.Expired)
                    continue;
                aura.Update(Time.deltaTime);
            }

            Auras.RemoveAll(a => a.Expired);
        }

        public void HealthChange(float amount)
        {
            health = Math.Clamp(health + amount, 0.0f, maxHealth);
        }
    }
}
