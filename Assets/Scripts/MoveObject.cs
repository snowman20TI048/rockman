using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("移動速度")]
    public float movespeed;

    // Update is called once per frame
    void Update()
    {
        //スクリプトがアタッチされているゲームオブジェクトの位置情報を更新して移動させる
        transform.position += new Vector3(-movespeed, 0, 0);
     
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
    /*    if(transform.position.x <= -14.0f)
        {
            //スクリプトがアタッチされているゲームオブジェクトを破壊
            Destroy(gameObject);
        }

    */
    }
}
