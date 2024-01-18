using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScene1Manager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(mySequence());
    }
    

    IEnumerator mySequence()
    {
        Debug.Log("I am waiting");
        yield return new WaitForSeconds(5f);
        // change the scene now
        ChangeTheScene(1);
    }

    public void ChangeTheScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
