using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;     //Dotweenを使うために必要

public class VerticalFloating : MonoBehaviour
{
    [Header("動くのにかかる時間")]
    public float moveTime;

    [Header("動く範囲")]
    public float moveRange;

    Tweener tweener; //DOTween の処理の代入用


    // Start is called before the first frame update
    void Start()
    {
        //DoTween による命令を実行し、それをTweener型のtweener変数に代入
        tweener = transform.DOMoveY(transform.position.y - moveRange, moveTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        
    }

    private void OnDestroy()  //そのゲームオブジェクトが削除されたときに行うメソッド
    {
        //ゲームオブジェクトの破棄に合わせてDoTweenの処理を破棄する（その結果、無限ループ処理を解消する）
        //Dotweenを実行するタイミングで変数に代入しておくことで、あとでDoTweenに命令を出すことが出来る
        tweener.Kill();
    }
}
