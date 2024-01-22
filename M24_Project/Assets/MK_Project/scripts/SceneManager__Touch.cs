using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManager__Touch : MonoBehaviour
{
    #region Variables

    [Header("Object Elements")]
    [SerializeField]
    private List<GameObject> modelLibrary = new List<GameObject>();

    [SerializeField]
    private GameObject rootModel;

    [SerializeField]
    private int totalNumberOfModels;
    [SerializeField]
    private int currentModel;

    

    [Header("UI Elements")]
    [SerializeField]     private Slider settingsVolumeSlider;
    [SerializeField]     private Slider settingsQualitySlider;
    [SerializeField]     private Button muteButton;
    [SerializeField]     private Button qualityButton;
    [SerializeField]     private Image muteButtonImageOn;
    [SerializeField]     private Sprite muteOnButtonTexture;
    [SerializeField]     private Sprite muteOffButtonTexture;



    #endregion

    #region UnityMainFunctions


    private void Start()
    {
        totalNumberOfModels = modelLibrary.Count;
        currentModel = 0;
        ShowModelOfID(currentModel);
        if (MainAudioManager.Instance == null)
        {
            MainAudioManager.Instance.PlayMyAudio();
        }
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


    public void SetAudioManagerMute()
    {
        // change value of mute to oposite
        MainAudioManager.Instance.isTheAudioMutted = !MainAudioManager.Instance.isTheAudioMutted;
        MainAudioManager.Instance.SetMute(MainAudioManager.Instance.isTheAudioMutted);

        // change the UI button to reflect current stage
        if (MainAudioManager.Instance.isTheAudioMutted)
        {
            muteButtonImageOn.sprite = muteOnButtonTexture;
        } else if (MainAudioManager.Instance.isTheAudioMutted == false)
        {
            muteButtonImageOn.sprite = muteOffButtonTexture;
        }

    }
    public void SetAudioManagerVolume()
    {
        // get value of the slider
        float volumeSliderValue = settingsVolumeSlider.value;
        MainAudioManager.Instance.SetVolume(volumeSliderValue);


       

    }
    #endregion
}