using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{

    //public int instructionsScene;
    // Start is called before the first frame update
    void Start()
    {
       // instructionsScene = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            print("Testing Game Start");
            SceneManager.LoadScene(1);
        }
    }
}
