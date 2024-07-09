using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class CombatLogManager : MonoBehaviour
    {
        // Singleton Pattern
        public static CombatLogManager Instance { get; private set; }
        
        void Awake()
        {
            Instance = this;
        }

        void StartCombat()
        {
            
        }

        void EndCombat()
        {
            
        }

        void AddLog()
        {

        }
        
        
        
        
    }
}