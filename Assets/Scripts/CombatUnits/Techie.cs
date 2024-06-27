namespace CombatUnits
{
    public class Techie : Unit
    {
        void Awake()
        {
            base.Awake();
            unitName = "Techie";
            resourceType = "Electricity";
            maxResource = 100;
            resourceRegen = 0;
        }

        void FixedUpdate()
        {
            
        }
    }
}