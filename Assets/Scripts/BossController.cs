using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("�̗�")]
    public float Hp;

    [SerializeField, Header("Linecast�p �n�ʔ��背�C���[")]
    private LayerMask groundLayer;

    private Animator anim;

    public bool isGrounded;

    public float jumpPower;                      // �W�����v�E���V��

    public float time;
    public float loadtime;

    private Rigidbody2D rb;                      // �R���|�[�l���g�̎擾�p

    [Header("���ԊԊu")]
    public float span = 2.0f; //1.0f�Ԋu�Œ��Ԃ悤��
    float delta = 0;  //

    [SerializeField]  //��������邱�ƂŁA�h���b�O���h���b�v�ł���悤�ɂȂ�B
    public PlayerController playerController;

    private float scale;

    private bool character_close;

   private bool  isClear = false;



    // Start is called before the first frame update
    void Start()
    {
        // �K�v�ȃR���|�[�l���g���擾���ėp�ӂ����ϐ��ɑ��
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        scale = transform.localScale.x;  //����ɂ��ŏ��̑傫����ۑ��ł���
      
    }

    // Update is called once per frame
    void Update()
    {
        ////* ��������ǉ� *////


        // �n�ʐڒn  Physics2D.Linecast���\�b�h�����s���āAGround Layer�ƃL�����̃R���C�_�[�Ƃ��ڒn���Ă��鋗�����ǂ������m�F���A�ڒn���Ă���Ȃ� true�A�ڒn���Ă��Ȃ��Ȃ� false ��߂�
        isGrounded = Physics2D.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 2.0f, groundLayer);

        // Scene�r���[�� Physics2D.Linecast���\�b�h��Line��\������
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
                // �W�����v
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
                //�e�ۂ�j�󂷂�
                Destroy(col.gameObject);

                Hp--;
                if (Hp <= 0 && isClear == false)
                {

                    Debug.Log("�Q�[���N���A");
                    isClear = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    /// �W�����v�Ƌ󒆕��V
    /// </summary>
    private void Jump()
    {
        // ��������I���W�i��
        if (isGrounded == true)
        {
            Vector3 dir = new Vector3(transform.localScale.x, 0, 0);
            // �{�X�̈ʒu����,�L�����N�^�[�����ֈړ�������(�W�����v�E���V)
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
