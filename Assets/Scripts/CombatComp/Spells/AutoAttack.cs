using System.Collections.Generic;
using WorldOfSim.CombatComp.Events;
using WorldOfSim.CombatUnits;

namespace WorldOfSim.CombatComp.Spells
{
    public class AutoAttack : SpellBase<AutoAttack>
    {
        public override void OnCast(Unit caster, List<Unit> targets)
        {
            foreach (var target in targets)
            {
                float RawDamage = Data.Values["AP1"] * caster.ap;
            }
            base.OnCast(caster, targets);
        }
    }
}