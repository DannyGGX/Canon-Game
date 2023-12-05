using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectiveEvaluator : MonoBehaviour
{
    [SerializeField] private Camera photographyCamera;
    [SerializeField] private LayerMask objectiveLayers;
    [SerializeField, Tooltip("For checking the current lens")] 
    private LensController lensController;

    private ObjectIdentifier objectIdentifier;
    private List<ObjectiveObject> objectsInView;

    private List<Objective> uncheckedObjectives;

    private void Awake()
    {
        objectIdentifier = new ObjectIdentifier(photographyCamera, objectiveLayers);
    }

    private void OnEnable()
    {
        EventManager.OnTakePhoto.Subscribe(TakePhoto);
    }

    private void OnDisable()
    {
        EventManager.OnTakePhoto.Unsubscribe(TakePhoto);
    }

    private void TakePhoto()
    {
        objectsInView = objectIdentifier.GetObjectsInCameraView();
        uncheckedObjectives = ObjectivesManager.Instance.IncompleteObjectives;

        foreach (var objective in uncheckedObjectives)
        {
            CheckIfAllObjectiveRequirementsAreMet(objective);
        }
    }

    private bool CheckIfAllObjectiveRequirementsAreMet(Objective objective)
    {
        if (objective.PositionConstraint)
        {
            float distance = Vector3.Distance(objective.Position, transform.position);
            if ((distance <= objective.MaxDistanceFromPosition) == false)
                return false;
        }
        if (objective.RequiresSpecificLens)
        {
            if (lensController.currentLens.Data.lensSettings.LensType != objective.RequiredLens)
                return false;
        }
        
        foreach (var obj in objective.Objects)
        {
            if (objectsInView.Contains(obj.Object) == false)
                return false;
            int count = objectsInView.Count(x => x.Name == obj.Object.Name);
            if ((count >= obj.Amount) == false)
                return false;
        }
    
        return true;
    }
    
}
