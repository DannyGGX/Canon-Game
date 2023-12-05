using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentifier : MonoBehaviour
{
    /// <summary>
    /// Can be a separate camera to the main camera.
    /// </summary>
    private Camera photographyCamera;
    private LayerMask objectiveLayers;
    
    private Plane[] cameraPlanes;
    private Collider[] colliders;
    private List<ObjectiveObject> objectsInView;
    private List<int> foundParentsObjectIDs;

    public void Initialise(Camera photographyCamera, LayerMask objectiveLayers)
    {
        this.photographyCamera = photographyCamera;
        this.objectiveLayers = objectiveLayers;
    }
    
    public List<ObjectiveObject> GetObjectsInCameraView()
    {
        cameraPlanes = GeometryUtility.CalculateFrustumPlanes(photographyCamera);
        colliders = Physics.OverlapSphere(photographyCamera.transform.position, photographyCamera.farClipPlane, objectiveLayers);
        objectsInView = new List<ObjectiveObject>();
        foundParentsObjectIDs = new List<int>();

        foreach (var collider in colliders)
        {
            if (GeometryUtility.TestPlanesAABB(cameraPlanes, collider.bounds) == false) continue;

            ObjectiveObject component;
            if (collider.gameObject.CompareTag("ObjectiveChildObject"))
            {
                component = collider.GetComponentInParent<ObjectiveObject>();
            }
            else
            {
                component = collider.GetComponent<ObjectiveObject>();
            }
            int id = component.GetInstanceID();
            if (foundParentsObjectIDs.Contains(id))
                continue;
            foundParentsObjectIDs.Add(id);
            objectsInView.Add(component);
        }

        return objectsInView;
    }

#if UNITY_EDITOR
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(photographyCamera.transform.position, photographyCamera.farClipPlane);
    // }
#endif
}
