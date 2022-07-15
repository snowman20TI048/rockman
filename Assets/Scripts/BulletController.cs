using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;                      // コンポーネントの取得用

    private float scale;                         // 向きの設定に利用する

    public float AttackPower;                      // アタック力
    // Start is called before the first frame update
    void Start()
    {
        // 必要なコンポーネントを取得して用意した変数に代入
        rb = GetComponent<Rigidbody2D>();



        scale = transform.localScale.x;
         //ここからオリジナル
                // アタック
       
                    Attack();
    }

    // Update is called once per frame
    void Update()
    {

       
        

    }

    private void Attack()
    {
        // ここからオリジナル

        // キャラの位置を上方向へ移動させる(ジャンプ・浮遊)
        rb.AddForce(transform.right * AttackPower);

    }


}
