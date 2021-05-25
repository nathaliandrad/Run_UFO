using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tittle : MonoBehaviour
{
    public int nextScene;

    public AudioSource speaker;

    // Start is called before the first frame update
    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

    }

    // Update is called once per frame
    void Update()
    {

      

        if (Input.GetKey(KeyCode.Return))
        {
            print("Testing Game Start");
            SceneManager.LoadScene(nextScene);
        }
        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene(6);
        }

    }
}
