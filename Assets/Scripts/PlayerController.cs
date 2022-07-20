using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string horizontal = "Horizontal";    // キー入力用の文字列指定


    private string jump = "Jump";　　　　　　　　// キー入力用の文字列指定



    private Rigidbody2D rb;                      // コンポーネントの取得用




    private Animator anim;





    private float scale;                         // 向きの設定に利用する

    public float moveSpeed;                      // 移動速度

    public float jumpPower;                      // ジャンプ・浮遊力



    [SerializeField, Header("Linecast用 地面判定レイヤー")]
    private LayerMask groundLayer;


    public bool isGrounded;

    public Transform bulletTran;              // バレットの生成位置の配列

    public GameObject bulletPrefab;              // バレットのプレファブ

    [Header("アタック待機時間")]
    public float loadtime;




    void Start()
    {
        // 必要なコンポーネントを取得して用意した変数に代入
        rb = GetComponent<Rigidbody2D>();





        anim = GetComponent<Animator>();



        scale = transform.localScale.x;
    }





    void Update()
    {

        ////* ここから追加 *////


        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isGrounded = Physics2D.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, groundLayer);

        // Sceneビューに Physics2D.LinecastメソッドのLineを表示する
        Debug.DrawLine(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, Color.red, 1.0f);



        // ジャンプ
        if (Input.GetButtonDown(jump))
        {    // InputManager の Jump の項目に登録されているキー入力を判定する
            Jump();
        }

        //ここからオリジナル
        // アタック
        if (Input.GetKeyDown(KeyCode.Z))
        {    // InputManager の Jump の項目に登録されているキー入力を判定する
             //コルーチン呼び出し
            StartCoroutine("attack");
        }




        // 接地していない(空中にいる)間で、落下中の場合
        if (isGrounded == false && rb.velocity.y < 0.15f)
        {
            // 落下アニメを繰り返す
            anim.SetTrigger("Fall");
        }


        ////* ここまで *////



    }

    /// <summary>
    /// ジャンプと空中浮遊
    /// </summary>
    private void Jump()
    {
        // ここからオリジナル
        if (isGrounded == true)
        {
            // キャラの位置を上方向へ移動させる(ジャンプ・浮遊)
            rb.AddForce(transform.up * jumpPower);

            // Jump(Up + Mid) アニメーションを再生する
            anim.SetTrigger("Jump");
        }
    }

    //コルーチン実行
    IEnumerator attack()
    {
        // ここからオリジナル
       
            // Attackアニメーションを再生する
            anim.SetTrigger("Attack");

        //0.1秒待機
        yield return new WaitForSeconds(loadtime);

        GameObject bullet = Instantiate(bulletPrefab, bulletTran);
       // Debug.Log(bullet);
        Vector3 dir = new Vector3(transform.localScale.x, 0, 0);
        bullet.GetComponent<BulletController>().Attack(dir); //F12で確認
        bullet.transform.SetParent(null);    //親子関係を解除

    }



    void FixedUpdate()
    {
        // 移動
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {

        // 水平(横)方向への入力受付
        float x = Input.GetAxis(horizontal);

        // x の値が 0 ではない場合 = キー入力がある場合
        if (x != 0)
        {

            // velocity(速度)に新しい値を代入して移動
            rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

            // temp 変数に現在の localScale 値を代入
            Vector3 temp = transform.localScale;

            // 現在のキー入力値 x を temp.x に代入
            temp.x = x;

            // 向きが変わるときに小数になるとキャラが縮んで見えてしまうので整数値にする            
            if (temp.x > 0)
            {

                //  数字が0よりも大きければすべて1にする
                temp.x = scale;

            }
            else
            {
                //  数字が0よりも小さければすべて-1にする
                temp.x = -scale;
            }

            // キャラの向きを移動方向に合わせる
            transform.localScale = temp;





            // 待機状態のアニメの再生を止めて、走るアニメの再生への遷移を行う
            anim.SetFloat("Run", 0.5f);    // ☆　追加  Run アニメーションに対して、0.5f の値を情報として渡す。遷移条件が greater 0.1 なので、0.1 以上の値を渡すと条件が成立してRun アニメーションが再生される

        }
        else
        {
            //  左右の入力がなかったら横移動の速度を0にしてすぐに停止する
            rb.velocity = new Vector2(0, rb.velocity.y);

            //  走るアニメの再生を止めて、待機状態のアニメの再生への遷移を行う
            anim.SetFloat("Run", 0.0f);     // ☆　追加  Run アニメーションに対して、0.f の値を情報として渡す。遷移条件が less 0.1 なので、0.1 以下の値を渡すと条件が成立してRun アニメーションが停止される




        }
    }
}