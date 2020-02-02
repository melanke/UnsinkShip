using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByAnyKey : MonoBehaviour
{
    [SerializeField] string sceneToChange;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }


    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ChangeScene();
        }
    }
}
