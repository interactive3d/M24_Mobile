using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager__Touch : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private List<GameObject> modelLibrary = new List<GameObject>();

    [SerializeField]
    private GameObject rootModel;

    [SerializeField]
    private int totalNumberOfModels;
    [SerializeField]
    private int currentModel;

    #endregion

    #region UnityMainFunctions
    private void Start()
    {
        totalNumberOfModels = modelLibrary.Count;
        currentModel = 0;
        ShowModelOfID(currentModel);
    }

    #endregion




    #region Functionalities

    public void ShowNextModel()
    {
        currentModel++;
        if (currentModel >= totalNumberOfModels) { 
            currentModel = 0;
        }
        ShowModelOfID(currentModel);
    }
    public void ShowPreviousModel() 
    { 
        currentModel--;
        if (currentModel < 0)
        {
            currentModel = totalNumberOfModels - 1;
        }
        ShowModelOfID(currentModel);
    }

    public void HideAllModels()
    {
        foreach (GameObject model in modelLibrary)
        {
            model.SetActive(false);
        }
    }

    public void ShowModelOfID(int modelID)
    {
        Debug.Log($"Model to deal is {modelID}");
        int myInt = modelID;
        for (int i = 0; i < modelLibrary.Count; i++)
        {
            if (i == myInt)
            {
                modelLibrary[i].SetActive(true);
                Debug.Log($"I am showing model {modelID}");
            } else{
                modelLibrary[i].SetActive(false);
                Debug.Log($"I am HIDING model {modelID}");
            }
        }
    }

    #endregion
}