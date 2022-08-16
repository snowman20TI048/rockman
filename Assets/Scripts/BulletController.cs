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
       // rb = GetComponent<Rigidbody2D>();



        scale = transform.localScale.x;
         //ここからオリジナル
                // アタック
       
                   // Attack();
    }

    // Update is called once per frame
    void Update()
    {

       
        

    }

    public void Attack(Vector3 dir)
    {
        // ここからオリジナル
        // 必要なコンポーネントを取得して用意した変数に代入
        rb = GetComponent<Rigidbody2D>();
        // 弾丸をキャラクターの向いている方向へ力を加える
        rb.AddForce( dir * AttackPower);

        Destroy(gameObject ,5.0f);

    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //Bulletを破壊
            Destroy(gameObject);
            //Enemyを破壊
            Destroy(col.gameObject);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //Bulletを破壊
            Destroy(gameObject);
        }

    }


}
