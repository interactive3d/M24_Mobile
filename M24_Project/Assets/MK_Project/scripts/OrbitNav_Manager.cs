using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitNav_Manager : MonoBehaviour
{
    // if this app is running on Editor (or Desktop) the enable the component for Mouse
    // otherwise if this is mobile then enable component for touch


    private void Awake()
    {
    #if UNITY_EDITOR
            gameObject.GetComponent<OrbitNav_Mouse>().enabled = true;
            gameObject.GetComponent<OrbitNav_Touch>().enabled = false;
    #endif
    #if UNITY_ANDROID
        gameObject.GetComponent<OrbitNav_Mouse>().enabled = false;
        gameObject.GetComponent<OrbitNav_Touch>().enabled = true;
    #endif


    }

}
