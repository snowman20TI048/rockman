using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要！！

public class TitleDirector : MonoBehaviour
{
    [Header("メインBGM")]
    [SerializeField]
    private AudioManager audioManager;              // ヒエラルキーにある AudioManager スクリプトのアタッチされているゲームオブジェクトをアサイン

    void Start()
    {
        // タイトル曲再生
        StartCoroutine(audioManager.PlayBGM(0));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
