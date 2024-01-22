using UnityEngine;

public class MainAudioManager : MonoBehaviour
{
    private static MainAudioManager instance; // reference to itself

    [Header("Volume Control Options")]
    public float currentVolume = 0.5f; // this is the volume value
    public bool isTheAudioMutted; // this will store information either the audio is or not mutted

    [Header("Reference to audio objects")]
    [SerializeField]
    private AudioSource defaultAudioSource; // reference to the audio source
    [SerializeField]
    private AudioClip defaultAudioClip; // reference to the specific default AudioClip that will be played

    public static MainAudioManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(MainAudioManager)) as MainAudioManager;
                //  instance = FindFirstObjectByType<MainAudioManager>();
                if (instance == null)
                {
                    GameObject persistantGO = new GameObject("MainAudioManager");
                    instance = persistantGO.AddComponent<MainAudioManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance !=this)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        defaultAudioSource = this.gameObject.AddComponent<AudioSource>(); // this will add the component to the GameObject
        defaultAudioSource.clip = this.defaultAudioClip; // this will add to newly created (added) component AudioSource an AudioClip
        currentVolume = 0.5f; // set the default volume level to 50% (0.5f)
        SetVolume(currentVolume); // use the method SetVolume to setup the currentVolume level
        isTheAudioMutted = false; // this is assigning value false to the variable (type bool)
        SetMute(isTheAudioMutted); // this just makes sure that at the start the mute value is not true
        PlayMyAudio(); // this will just start playing the audio
    }

    public void SetMute() {
        defaultAudioSource.mute = true;
    }
    public void SetMute(bool newMuteValue) {
        defaultAudioSource.mute = newMuteValue;  // this will change the value on the AudioSource of the field "mute" to whatever the bool is
    }
    public void SetVolume()
    {
        // find slider for vulme
        // the the value of the slider
        // setVolume to that value
    }
    public void SetVolume(float newVolumeValue) { 
        defaultAudioSource.volume = newVolumeValue; // this will change the volume value on the AudioSource component
    }

    public void ChangeAudioBg(AudioClip newAudioClip) {
        defaultAudioSource.clip = newAudioClip;
    }

    public void PlayMyAudio()
    {
        Debug.Log("Play my default audio at the start");
        defaultAudioSource.Play();
    }
}
