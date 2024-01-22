using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScene1Manager : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;     // reference to the animator of the FadeIn/Out
    
    
    private void Start()
    {
        StartCoroutine(mySequence());
    }
    

    IEnumerator mySequence()
    {
        Debug.Log("I am waiting");
        yield return new WaitForSeconds(4f);
        // here to start the animation of fade out
        myAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.1f);
        // change the scene now
        ChangeTheScene(1);
    }

    public void ChangeTheScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
