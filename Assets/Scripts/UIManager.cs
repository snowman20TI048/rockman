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


    ////* ここから追加 *////

    [SerializeField]
    private ResultPopUp resultPopUpPrefab;

    [SerializeField]
    private Transform canvasTran;

    ////* ここまで *////


    /// <summary>
    /// ゲームオーバー表示
    /// </summary>
    public void DisplayGameOverInfo()
    {

        // InfoBackGround ゲームオブジェクトの持つ CanvasGroup コンポーネントの Alpha の値を、1秒かけて 1 に変更して、背景と文字が画面に見えるようにする
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        // 文字列をアニメーションさせて表示
        txtInfo.DOText("Game Over...", 1.0f);
    }


    ////* 新しくメソッドを１つ追加。ここから *////

    /// <summary>
    /// ResultPopUpの生成
    /// </summary>
    public void GenerateResultPopUp()
    {
        // ResultPopUp を生成
        ResultPopUp resultPopUp = Instantiate(resultPopUpPrefab, canvasTran, false);

        // ResultPopUp の設定を行う
        resultPopUp.SetUpResultPopUp();
    }

    ////* ここまで *////

}