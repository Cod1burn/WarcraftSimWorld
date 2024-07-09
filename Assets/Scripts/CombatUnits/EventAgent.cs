using CombatComp.Events;
using System.Collections.Generic;

namespace CombatUnits{
    public sealed class EventAgent
    {
        Unit unit;

        List<CombatEvent> cevents;

        public EventAgent(Unit unit)
        {
            this.unit = unit;
        }

        public void ProcessEvent(CombatEvent cevent)
        {
            
        }

        public void ReceiveEvent(CombatEvent cevent)
        {

        }

    }
}