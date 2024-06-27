using System.Collections.Generic;
using CombatUnits;

namespace CombatComp.Spells
{
    public class Spell
    {
        public string Name;

        public static int SpellID;

        public string Description;
        
        public bool Channeling;
        
        public float CastTime;

        public float ChannelTime;

        public float ChannelTick;
        
        public Unit Caster;

        public int MaxTargets;

        public List<Unit> Targets;
        
        public float Cooldown;

        public float CdRate;

        public float CdTimer;

        public bool HasteCooldown;

        public bool GlobalCooldown;

        public float Resource;

        public SpellModifier[] Modifiers;

        public Dictionary<string, float> Values;
        
        public virtual void StartCast(Unit caster, List<Unit> targets)
        {
            Caster = caster;
            Targets = targets;
        }

        public virtual void OnCast()
        {
            foreach (var modifier in Modifiers)
                modifier.OnCast();
        }

        public virtual void OnChannelTick()
        {
            
        }
        
        public void Update(float deltaTime)
        {
           if (CdTimer > 0.0f)
            {
                CdTimer -= deltaTime;
            }
        }
    }
}