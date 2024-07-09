using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class CombatLogManager : MonoBehaviour
    {
        // Singleton Pattern
        public static CombatLogManager Instance { get; private set; }

        public long tickNo;

        List<CombatLog> logs;
        
        DateTime startTime;
        
        void Awake()
        {
            Instance = this;
        }

        void FixedUpdate()
        {
            tickNo++;
        }

        void StartCombat()
        {
            logs = new List<CombatLog>();
            startTime = DateTime.Now;
            tickNo = 0;
        }

        void EndCombat()
        {
            Debug.Log("Combat Ended, total ticks: " + tickNo);
            SaveLogs();
        }

        void AddLog(CombatLog log)
        {
            logs.Add(log);
        }
        
        void SaveLogs()
        {
            //TODO: specify the log directory
            string path = $"CombatLog_{startTime}.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            foreach (CombatLog log in logs)
            {
                file.WriteLine(log.ToString());
            }
            file.Close();
        }
        
        
        
    }
}