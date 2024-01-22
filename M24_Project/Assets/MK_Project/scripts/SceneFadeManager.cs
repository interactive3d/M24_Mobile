using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
    [SerializeField]
    private Image fadingImage; // reference to the image used in the fade

    [SerializeField]
    private Animator myDefaultFadeAnimator; // reference to the animator

    public GameObject UIEl;

    [SerializeField]
    private static GameObject UI_Screen; // reference to the screen cover UI elements


    private static SceneFadeManager sInstance;
    public static SceneFadeManager Instance
    {
        get { 
            if (sInstance == null)
            {
                sInstance = FindObjectOfType<SceneFadeManager>();
                if (sInstance == null)
                {
                    GameObject newGO = new GameObject("_MySceneFadeInOutManager");
                    GameObject childOb = Instantiate(UI_Screen, newGO.transform);
                    sInstance = newGO.AddComponent<SceneFadeManager>();
                    sInstance.GetComponent<SceneFadeManager>().fadingImage = childOb.transform.GetChild(0).GetComponent<Image>();
                    sInstance.GetComponent<SceneFadeManager>().myDefaultFadeAnimator = childOb.transform.GetChild(0).GetComponent<Animator>();
                }
            }
            return sInstance; 
        }
    }
    private void Awake()
    {
        if (sInstance != null && sInstance !=this) {

            Destroy(this.gameObject);
        } else
        {
            sInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void StartFadeOut()
    {
        this.myDefaultFadeAnimator.SetTrigger("FadeOut");
    }
    public void StartFadeIn()
    {
        this.myDefaultFadeAnimator.Play("FadeAnimation");
    }
}
