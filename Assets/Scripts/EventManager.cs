using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Singleton Pattern
    public static EventManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    
    
}
