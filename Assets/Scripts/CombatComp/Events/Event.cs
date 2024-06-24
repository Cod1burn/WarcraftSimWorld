using UnityEngine;

namespace CombatComp.Events
{
    public enum EventType
    {
        DamageEvent,
        HealEvent,
        SpellEvent,
        AuraEvent
    }
    
    public class Event
    {
        public EventType Type;

        public Time TimeStamp;

        public virtual string EventString()
        {
            return "";
        }
    }
}