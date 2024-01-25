using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneManager_VR : MonoBehaviour
{
    [SerializeField]    private UnityEvent OnPreviousButtonSelected;
    [SerializeField]    private UnityEvent OnNextButtonSelected;
    [SerializeField]    private UnityEvent OnCloseButtonSelected;


    private Ray myRay;

    private RaycastHit hitData; // reference to the hit data from Physics Raycast

    [SerializeField]
    private GameObject myReticle;
    
    [SerializeField]
    private LayerMask myLayerMask; // I defined the layermask

    private void Update()
    {
        myRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(myRay, out hitData, 100, myLayerMask))
        {
            GraphicRaycaster myGraphicRaycaster = hitData.collider.GetComponent<GraphicRaycaster>();
            if(myGraphicRaycaster != null)
            {
                PointerEventData myPointerEventData = new PointerEventData(EventSystem.current);
                myPointerEventData.position = new Vector2(Screen.width/4, Screen.height/2); // this to replace with the center of the screen

                List<RaycastResult> results = new List<RaycastResult>();
                myGraphicRaycaster.Raycast(myPointerEventData, results);
                if (results.Count > 0) { 
                    // this is for UI
                    if (results[0].gameObject.name == "btn_prev")
                        {
                        // I am hiting previous button
                        Debug.Log("Prev button");
                        OnPreviousButtonSelected?.Invoke();

                        }
                    if (results[0].gameObject.name == "btn_next")
                    {
                        Debug.Log("Next button");
                        // I am hiting the next obj. button
                        OnNextButtonSelected?.Invoke();
                    }
                    if (results[0].gameObject.name == "btn_close")
                    {
                        Debug.Log("Close button");
                        //  I am hiting close button
                        OnCloseButtonSelected?.Invoke();
                    }

                }
            }

            
        }
    }
}
