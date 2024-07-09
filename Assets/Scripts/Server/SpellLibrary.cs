using UnityEngine;
using System.Collections.Generic;
using WorldOfSim.CombatComp.Spells;

namespace WorldOfSim.Server
{   
    public class SpellLibrary : MonoBehaviour {

        public static SpellLibrary Instance { get; private set; }

        public Dictionary<int, SpellBase<object>> library;


        void Awake()
        {
            Instance = this;
            library = new Dictionary<int, SpellBase<object>>();
        }   

        void InitializeSpells()
        {
            // Loop through all files in Assets/Data/SpellData and get all of their file name in string
            string spellDataPath = "Assets/Data/SpellData";
            string[] spellFiles = System.IO.Directory.GetFiles(spellDataPath);

            foreach (string spellFile in spellFiles)
            {
                string spellFileName = System.IO.Path.GetFileNameWithoutExtension(spellFile);
                // TODO: string name to class name
            }

        }
    }
    
}