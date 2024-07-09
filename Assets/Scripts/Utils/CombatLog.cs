using UnityEngine;
using System;
using Utils;

namespace Utils
{

    public enum LogType
    {
        Damage,
        Healing,
        AuraApplied,
        AuraExpired,
        StartCasting,
        SpellCast,
        Triggered
    }

    public class CombatLog
    {
        // Timestamp of the log
        DateTime timestamp;
        long tickNo;
        string message;
        LogType type;
        public CombatLog(LogType type, string message)
        {
            // Get the system time
            timestamp = DateTime.Now;
            tickNo = CombatLogManager.Instance.tickNo;
            this.type = type;
            this.message = message;
        }

        public override string ToString()
        {
            return $"{timestamp}({tickNo})[{type}]: {message}";
        }
        
    }
}