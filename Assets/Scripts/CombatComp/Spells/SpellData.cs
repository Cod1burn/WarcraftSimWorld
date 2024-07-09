using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

namespace WorldOfSim.CombatComp.Spells
{
    [Serializable]
    public class SpellValuePair<TKey, TValue>
    {
        [XmlElement("key")]
        public TKey Key { get; set; }

        [XmlElement("value")]
        public TValue Value { get; set; }
    }
    
    [XmlRoot(ElementName = "spell")]
    public sealed class SpellData
    {
       
        [XmlElement("id")]
        public int SpellID;

        [XmlElement("name")]
        public string Name;

        [XmlElement("description")]
        public string Description;
        
        [XmlElement("castTime")]
        public float BaseCastTime;

        [XmlElement("channelTime")]
        public float BaseChannelTime;

        [XmlElement("channelTick")]
        public float ChannelTick;

        [XmlElement("targets")]
        public int MaxTargets;
        
        [XmlElement("cooldown")]
        public float BaseCooldown;

        [XmlElement("isHasteCd")]
        public bool HasteCooldown;

        [XmlElement("isGCd")]
        public bool GlobalCooldown;

        [XmlElement("cost")]        
        public float Cost;

        [XmlArray("valuePairs")]
        [XmlElement("pair")]
        public List<SpellValuePair<string, float>> ValuePairs;
        

        /// <summary>
        /// Naming logic of keys in Values:
        /// Attack Power Multiplier: AP1, AP2, AP3, ...
        /// Spell Power Multiplier: SP1, SP2, SP3, ...
        /// Duration related value: DR1, DR2, DR3, ...
        /// Probability related value: PR1, PR2, PR3, ...
        /// Other values: V1, V2, V3, ...
        /// The numbers are based on the order appearing in the description
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, float> Values;

        public SpellData()
        {}

        public void Initialize()
        {
            Values = new Dictionary<string, float>();
            foreach (SpellValuePair<string, float> pair in ValuePairs)
            {
                Values.Add(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Import spell data from database
        /// </summary>
        /// <param name="path">All spell data are in the directory Assets/Data/SpellData/</param>
        /// <returns></returns>
        public static SpellData Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SpellData));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as SpellData;
            }
        }
    }
}