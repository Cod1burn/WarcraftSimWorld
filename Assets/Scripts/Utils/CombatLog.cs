using UnityEngine;
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
        Time timestamp;
        string message;
        LogType type;
        public CombatLog(LogType type, string message)
        {
            this.type = type;
            this.message = message;
        }

        public string ToString()
        {
            return $"{timestamp}[{type}]: {message}";
        }
        
    }
}