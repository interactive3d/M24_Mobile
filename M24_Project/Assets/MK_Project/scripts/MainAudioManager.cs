using UnityEngine;

public class MainAudioManager : MonoBehaviour
{
    private static MainAudioManager instance;
    public float currentVolume = 0.5f;
    public bool isTheAudioMutted;
    [SerializeField]
    private AudioSource defaultAudioSource;
    [SerializeField]
    private AudioClip defaultAudioClip;

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
        defaultAudioSource = this.gameObject.AddComponent<AudioSource>();
        defaultAudioSource.clip = this.defaultAudioClip;
        currentVolume = 0.5f;
        SetVolume(currentVolume);
        isTheAudioMutted = false;
        SetMute(isTheAudioMutted);
        PlayMyAudio();
    }

    public void SetMute() {
        defaultAudioSource.mute = true;
    }
    public void SetMute(bool mute) {
        defaultAudioSource.mute = mute;
    }
    public void SetVolume()
    {
        // find slider for vulme
        // the the value of the slider
        // setVolume to that value
    }
    public void SetVolume(float volume) { 
        defaultAudioSource.volume = volume;
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
