using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneGlassPig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 2f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
