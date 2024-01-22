using UnityEngine;

public class MySingExample : MonoBehaviour
{
    private static MySingExample instance;

    public static MySingExample Instance
    {
        get { 
            if (instance == null)
            {
                instance = FindObjectOfType<MySingExample>();
            }
            if (instance == null)
            {
                GameObject myGameObject = new GameObject("MY NEW GAME OBJECT"); // this will create a game object
                myGameObject.AddComponent<MySingExample>();
            }

            return instance; 
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this) { 
            Destroy(this.gameObject);
        } else
        {
            instance = this; // use me as an instance of this class
            DontDestroyOnLoad(this.gameObject); // don't destroy this gameObject
        }
    }

    public void DoSomething()
    {
        Debug.Log("Do something");
    }
}
