using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using WorldOfSim.CombatComp.Spells;
using System.Data.Common;

namespace WorldOfSim.Server
{   
    public class SpellLibrary : MonoBehaviour {

        public static SpellLibrary Instance { get; private set; }

        public Dictionary<int, SpellBase<object>> library;


        void Awake()
        {
            Instance = this;
            library = new Dictionary<int, SpellBase<object>>();
            InitializeSpells();
        }   

        void InitializeSpells()
        {
            // Loop through all files in Assets/Data/SpellData and get all of their file name in string
            string spellDataPath = "Assets/Data/SpellData";
            string[] spellFiles = System.IO.Directory.GetFiles(spellDataPath);

            foreach (string spellFile in spellFiles)
            {
                if (System.IO.Path.GetExtension(spellFile) != ".xml")
                {
                    continue;
                }
                string spellName = System.IO.Path.GetFileNameWithoutExtension(spellFile);
                string assemblyName = "WorldOfSim.CombatComp.Spells.";
                string spellClassName = assemblyName + spellName;
                object instance = Activator.CreateInstance(Type.GetType(spellClassName));
                if (instance != null)
                {
                    SpellBase<object> spell = instance as SpellBase<object>;
                    SpellData spellData = SpellData.Load(spellFile);
                    spell.Data = spellData;
                    library.Add(spell.Data.SpellID, spell);
                }            
            }

        }
    }
    
}