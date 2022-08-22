using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要！！

public class TitleDirector : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
