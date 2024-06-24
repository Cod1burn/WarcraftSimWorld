using CombatUnits;

namespace CombatComp.Spells
{
    public class Spell
    {
        public string Name;

        public string Description;
        
        public bool Channeling;
        
        public float CastTime;

        public float ChannelTime;

        public float ChannelTick;
        
        public Unit Caster;
        
        public Unit Target;
        
        public float Cooldown;

        public float CdRate;

        public float CdTimer;

        public bool HasteCooldown;

        public bool GlobalCooldown;

        public float Resource;
        
        public virtual void StartCast(Unit caster, Unit target)
        {
            Caster = caster;
            Target = target;
        }

        public virtual void OnCast()
        {
            
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