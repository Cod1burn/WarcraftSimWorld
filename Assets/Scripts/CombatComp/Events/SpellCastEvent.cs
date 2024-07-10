using WorldOfSim.CombatUnits;

namespace WorldOfSim.CombatComp.Events
{
    public class SpellCastEvent : CombatEvent
    {
        public int SpellID;
        public Unit Caster;
        public Unit Target;

        public SpellCastEvent(int spellID, Unit caster, Unit target)
        {
            Type = EventType.SpellCastEvent;
            SpellID = spellID;
            Caster = caster;
            Target = target;
        }
    }
}