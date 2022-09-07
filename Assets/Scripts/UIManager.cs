using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtInfo;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;

    [SerializeField]
    private ResultPopUp resultPopUpPrefab;

    [SerializeField]
    private Transform canvasTran;

    [SerializeField]
    private Button btnInfo;

    [Header("BGM")]
    [SerializeField]
    private AudioManager audioManager;              // ヒエラルキーにある AudioManager スクリプトのアタッチされているゲームオブジェクトをアサイン

    /// <summary>
    /// ゲームオーバー表示
    /// </summary>
    public void DisplayGameOverInfo()
    {
        // ゲームオーバー曲再生
        StartCoroutine(audioManager.PlayBGM(2));

        // InfoBackGround ゲームオブジェクトの持つ CanvasGroup コンポーネントの Alpha の値を、1秒かけて 1 に変更して、背景と文字が画面に見えるようにする
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        // 文字列をアニメーションさせて表示
        txtInfo.DOText("Game Over...", 1.0f);

        btnInfo.onClick.AddListener(RestartGame);


    }



    /// <summary>
    /// ResultPopUpの生成
    /// </summary>
    public void GenerateResultPopUp()
    {
       

        // ResultPopUp を生成
        ResultPopUp resultPopUp = Instantiate(resultPopUpPrefab, canvasTran, false);

        // ResultPopUp の設定を行う
        resultPopUp.SetUpResultPopUp();

        btnInfo.onClick.AddListener(RestartGame);
    }



    /// <summary>
    /// タイトルへ戻る
    /// </summary>
    public void RestartGame()
    {

        // ボタンからメソッドを削除(重複クリック防止)
        btnInfo.onClick.RemoveAllListeners();

       /* // 現在のシーンの名前を取得
        string sceneName = SceneManager.GetActiveScene().name;
       */
        canvasGroupInfo.DOFade(0f, 1.0f)
            .OnComplete(() => {
                Debug.Log("Restart");
                SceneManager.LoadScene("TitleScene");
            });
    }

}