using System;
using System.Collections.Generic;
using WorldOfSim.CombatComp.Events;
using WorldOfSim.CombatUnits;

namespace WorldOfSim.CombatComp.Spells
{
    public class SpellBase<TSpell> where TSpell : class, new ()
    {
        private static readonly Lazy<TSpell> lazyInstance = new Lazy<TSpell>(() => new TSpell());

        public SpellData Data;

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
        {
            foreach (var target in targets)
            {
                SpellCastEvent e = new SpellCastEvent(Data.SpellID, caster, target);
                caster.agent.ReceiveEvent(e);
            }
        }

        public virtual void OnChannelTick(Unit caster, List<Unit> targets)
        {}
        
    }
}