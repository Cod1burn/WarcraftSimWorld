using System;
using System.Collections.Generic;
using CombatUnits;

namespace CombatComp.Spells
{
    public class SpellBase<TSpell> where TSpell : class, new ()
    {
        private static readonly Lazy<TSpell> lazyInstance = new Lazy<TSpell>(() => new TSpell());

        public SpellData Data {get; protected set;}

        protected SpellBase()
        {
        }

        public static TSpell Instance 
        { 
            get 
            {
                return lazyInstance.Value;
            }
        }

        public virtual void OnStartCast(Unit caster, List<Unit> targets)
        {}

        public virtual void OnCast(Unit caster, List<Unit> targets)
        {}

        public virtual void OnChannelTick(Unit caster, List<Unit> targets)
        {}
        
    }
}