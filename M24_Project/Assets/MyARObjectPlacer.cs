using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MyARObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager raycastManager; // reference to my Raycast manager

    [SerializeField]
    private GameObject myObjectToSpawn; // reference to prefab of the object that I want to place in AR recognized space

    List<ARRaycastHit> myHitsList = new List<ARRaycastHit>(); // this is a list of all the hits

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, myHitsList, TrackableType.Planes)){
                Debug.Log($"You just hit the plane");
                Pose pose = new Pose(); // I created a temporary object of the pose
                pose = myHitsList[0].pose; // this will assign the pose from the first hit to the temporary variable of Pose type

                GameObject mySpawnedNewObject = Instantiate(myObjectToSpawn, pose.position, pose.rotation);
            }
        }
    }

}
