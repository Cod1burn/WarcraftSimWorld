# Game demo

## Combat Logic

* **CombatAgent**: Owned by unit. Send combat-related events to **CombatEventManager**. Triggers within the unit will be processed by CombatAgent, and wont be passed to CombatEventManager.

* **CombatEventManager**: Take events from **CombatAgent**, process events such as target selection, damage calculation.

## Event types

* Damage: Dealing damage, with raw damage, reduction, absorb and overkill details including.