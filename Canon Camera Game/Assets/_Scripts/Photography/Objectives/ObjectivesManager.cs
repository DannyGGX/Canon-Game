using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (Instance == null)
        {
            Instance = this;
        }
        
        // Make IncompleteObjectives a copy of Objectives so that it doesn't Remove elements from Objectives.
        Objective[] incompleteObjectives = new Objective[Objectives.Count];
        Objectives.CopyTo(incompleteObjectives);
        IncompleteObjectives = incompleteObjectives.ToList();

        EventManager.OnCompletedObjective.Subscribe(ObjectiveCompleted);
    }

    private void OnDisable()
    {
        EventManager.OnCompletedObjective.Unsubscribe(ObjectiveCompleted);
    }

    private void ObjectiveCompleted(Objective objective)
    {
        IncompleteObjectives.Remove(objective);
    }
}
