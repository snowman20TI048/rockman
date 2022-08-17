using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("体力")]
    public float Hp;

    [SerializeField, Header("Linecast用 地面判定レイヤー")]
    private LayerMask groundLayer;

    private Animator anim;

    public bool isGrounded;

    public float jumpPower;                      // ジャンプ・浮遊力

    public float time;
    public float loadtime;

    private Rigidbody2D rb;                      // コンポーネントの取得用

    [Header("跳ぶ間隔")]
    public float span = 2.0f; //1.0f間隔で跳ぶように
    float delta = 0;  //

    [SerializeField]  //これをつけることで、ドラッグ＆ドロップできるようになる。
    public PlayerController playerController;

    private float scale;

    private bool character_close;

   private bool  isClear = false;



    // Start is called before the first frame update
    void Start()
    {
        // 必要なコンポーネントを取得して用意した変数に代入
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        scale = transform.localScale.x;  //これにより最初の大きさを保存できる
      
    }

    // Update is called once per frame
    void Update()
    {
        ////* ここから追加 *////


        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isGrounded = Physics2D.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 2.0f, groundLayer);

        // Sceneビューに Physics2D.LinecastメソッドのLineを表示する
        Debug.DrawLine(transform.position + transform.up * 0.4f, transform.position - transform.up * 2.0f, Color.red, 1.0f);

        if (transform.position.x - playerController.transform.position.x < 10.0f)
        {
            character_close = true;
        }


        if (character_close == true)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                // ジャンプ
                if (isGrounded == true)
                {
                    // Debug.Log(isGrounded);
                    Jump();
                    isGrounded = false;
                }
            }
        }

       

       





       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (character_close == true)
            {
                //弾丸を破壊する
                Destroy(col.gameObject);

                Hp--;
                if (Hp <= 0 && isClear == false)
                {

                    Debug.Log("ゲームクリア");
                    isClear = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    /// ジャンプと空中浮遊
    /// </summary>
    private void Jump()
    {
        // ここからオリジナル
        if (isGrounded == true)
        {
            Vector3 dir = new Vector3(transform.localScale.x, 0, 0);
            // ボスの位置を上,キャラクター方向へ移動させる(ジャンプ・浮遊)
            //rb.AddForce(transform.up * jumpPower,ForceMode2D.Impulse);
            //rb.AddForce(-20 * dir, ForceMode2D.Impulse);
            if (transform.position.x > playerController.transform.position.x) {
                rb.AddForce(new Vector3(-1, 1, 0) * jumpPower, ForceMode2D.Impulse);
                transform.localScale = new Vector3(scale, scale, scale);
                anim.SetTrigger("Jump");
            }
            else
            {
                rb.AddForce(new Vector3(1, 1, 0) * jumpPower, ForceMode2D.Impulse);
                transform.localScale = new Vector3(-scale, scale, scale);
                anim.SetTrigger("Jump");
            }

        }
    }


}
