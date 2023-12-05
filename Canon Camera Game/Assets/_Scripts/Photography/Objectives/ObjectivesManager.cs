using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [field: SerializeField] public List<Objective> Objectives { get; private set; }
    
    /// <summary>
    /// Iterate through this list for finding objects. Objectives list UI also needs to access this.
    /// </summary>
    public List<Objective> IncompleteObjectives { get; set; }
    
    public static ObjectivesManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance = null)
        {
            Instance = this;
        }

        IncompleteObjectives = Objectives;
    }
    
    
}
