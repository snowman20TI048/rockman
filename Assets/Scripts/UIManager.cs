using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;   //DoTweenを利用するために宣言を追加

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtInfo;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;


    //ゲームオーバー表示
    public void DisplayGameOverInfo()
    {
        //InfoBackGroundゲームオブジェクトの持つCanvasGroupコンポーネントのAlphaの値を、
        //1秒かけて1に変更して、背景と文字が見えるようにする
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        //文字列をアニメーションさせて表示
        txtInfo.DOText("Gane Over ...", 1.0f);

    }


}
