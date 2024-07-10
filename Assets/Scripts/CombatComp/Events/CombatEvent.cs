using UnityEngine;

namespace WorldOfSim.CombatComp.Events
{
    public enum EventType
    {
        DamageEvent,
        HealEvent,
        SpellCastEvent,
        SpellTakenEvent,
        AuraAppliedEvent,
        AuraRemovedEvent,
    }
    
    public class CombatEvent
    {
        public EventType Type;
    }
}