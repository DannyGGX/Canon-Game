using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesList : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private EntryUI entryPrefab;
    [SerializeField] private Vector3 startingEntryPosition;
    [SerializeField] private float verticalSpacing;
    
    //private TextMeshProUGUI[] 
    private bool isListOpen = false;
    private List<Objective> objectives;
    private List<EntryUI> entries;

    private void Start()
    {
        CreateListEntries();
        EventManager.OnCompletedObjective.Subscribe(CompleteObjective);
    }

    private void OnDisable()
    {
        EventManager.OnCompletedObjective.Unsubscribe(CompleteObjective);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleObjectiveList(isListOpen);
        }
    }

    private void ToggleObjectiveList(bool isCurrentlyOpen)
    {
        isCurrentlyOpen = !isCurrentlyOpen;
        ui.SetActive(isCurrentlyOpen);
        isListOpen = isCurrentlyOpen;
        EventManager.OnObjectivesListOpen.Invoke(isCurrentlyOpen);
    }
    public void OpenObjectivesList() // public so that buttons can call this
    {
        ToggleObjectiveList(false);
    }
    public void CloseObjectivesList() // public so that buttons can call this
    {
        ToggleObjectiveList(true);
    }

    private void CreateListEntries()
    {
        Vector3 currentEntryPosition = startingEntryPosition;
        objectives = ObjectivesManager.Instance.Objectives;
        entries = new List<EntryUI>(objectives.Count);
        
        foreach (var objective in objectives)
        {
            EntryUI entry = GameObject.Instantiate(entryPrefab, currentEntryPosition, Quaternion.identity, ui.transform);

            if (objective.RequiresSpecificLens)
            {
                entry.SetEntryInfo(objective.Description, objective.RequiredLens);
            }
            else
            {
                entry.SetEntryInfo(objective.Description);
            }
            entries.Add(entry);
            currentEntryPosition.y -= verticalSpacing;
        }
    }

    private void CompleteObjective(Objective objective)
    {
        int index = objectives.IndexOf(objective);
        entries[index].SetEntryComplete();
    }
}
