using UnityEngine;
using System.Collections.Generic;
using WorldOfSim.CombatComp.Spells;

namespace WorldOfSim.Server
{   
    public class SpellLibrary : MonoBehaviour {

        public static SpellLibrary Instance { get; private set; }
        


        void Awake()
        {
            Instance = this;
        }   

        void InitializeSpells()
        {
            // Add spells to the library here
        }
    }
    
}