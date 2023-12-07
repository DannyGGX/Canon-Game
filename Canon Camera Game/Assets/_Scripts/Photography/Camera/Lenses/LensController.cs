using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensController : MonoBehaviour
{
    [SerializeField, Tooltip("Empty gameObject to show where to place lenses")] 
    private Transform lensPoint;
    [SerializeField] private Camera photographyCamera;
    [SerializeField] private List<Lens> startingLenses;

    public Node<Lens> currentLens { get; private set; }
    private Lens currentLensPrefab;
    private CustomLinkedList<Lens> lensSelection;

    private void Awake()
    {
        InitialiseLensSelection();
    }
    private void OnEnable()
    {
        EventManager.OnChangeLens.Subscribe(ChangeLens);
    }

    private void OnDisable()
    {
        EventManager.OnChangeLens.Unsubscribe(ChangeLens);
    }

    private void InitialiseLensSelection()
    {
        lensSelection = new CustomLinkedList<Lens>();

        foreach (var lens in startingLenses)
        {
            lensSelection.Add(lens);
        }

        currentLens = lensSelection.Head;
        currentLensPrefab = Instantiate(currentLens.Data, lensPoint.position, lensPoint.rotation, lensPoint);
        ApplyCurrentLensSettings();
        
        // Clear memory
        startingLenses.Clear();
        startingLenses.Capacity = 0;
    }
    private void ChangeLens(bool scrollUp)
    {
        if (lensSelection.Length == 1) return;
        
        if (scrollUp)
            currentLens = currentLens.NextNode;
        else
            currentLens = currentLens.PreviousNode;
        ApplyCurrentLensSettings();
    }

    private void ApplyCurrentLensSettings()
    {
        currentLensPrefab = currentLens.Data;
        LensSO lensSettings = currentLens.Data.lensSettings;
        photographyCamera.fieldOfView = lensSettings.FieldOfView;
    }
}
