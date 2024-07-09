using System.Collections.Generic;
using CombatUnits;

namespace CombatComp.Spells
{
    public class SpellModifier
    {
        public string Name;
        
        public static int ModifierID;

        public string Description;

        public BaseSpell Spell;

        public SpellModifier()
        { }

        public virtual void OnApply(BaseSpell spell)
        {
            Spell = spell;
        }
        
        public virtual void OnRemove()
        {}

        public virtual void OnCast() {}
    }
}