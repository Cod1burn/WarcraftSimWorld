using System;
using System.Collections;
using System.Collections.Generic;
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

        public float resourceRegen;

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
        public float mainHandDmg;
        
        public float mainHandInterval;
        
        public float mainHandSpeed;
        
        public float offHandDmg;

        public float offHandInterval;

        public float offHandSpeed;
        
        // Condition
        public List<Aura> Auras;
        
        // Spells
        public List<Spell> SpellBook;
        
        public Spell CastingSpell;

        public float castTimer;
        
        public float globalCooldown;
        
        public float gcdTimer;
        
        // Start is called before the first frame update
        void Awake()
        {
            Auras = new List<Aura>();
            SpellBook = new List<Spell>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            foreach (Spell spell in SpellBook)
            {
                if (spell.Cooldown > 0.0f && spell.CdTimer > 0.0f)
                {
                    if (spell.HasteCooldown)
                        spell.Update(Time.deltaTime * (1.0f + haste) * spell.CdRate);
                    else
                        spell.Update(Time.deltaTime * spell.CdRate);
                }
            }
            
            foreach (Aura aura in Auras)
            {
                if (aura.Expired)
                    continue;
                aura.Update(Time.deltaTime);
            }

            Auras.RemoveAll(a => a.Expired);
        }

        public void TakeDamage(Damage damage)
        {
            float finalDamage = damage.RawDamage * dmgTakenMultiplier;
            if (damage.DamageType == DamageType.Physical) finalDamage *= 1.0f - physicalResist;
            else if (damage.DamageType != DamageType.Chaos) finalDamage *= 1.0f - magicalResist;
            
            health = Math.Clamp(health - finalDamage, 0.0f, maxHealth);
            DamageEvent de = new DamageEvent(damage, this, finalDamage);
        }
        
    }
}
