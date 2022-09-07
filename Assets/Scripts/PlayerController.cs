using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string horizontal = "Horizontal";    // �L�[���͗p�̕�����w��


    private string jump = "Jump";�@�@�@�@�@�@�@�@// �L�[���͗p�̕�����w��



    private Rigidbody2D rb;                      // �R���|�[�l���g�̎擾�p

    private bool isAttack;



    private Animator anim;

    public UIManager UIManager;




    private float scale;                         // �����̐ݒ�ɗ��p����

    public float moveSpeed;                      // �ړ����x

    public float jumpPower;                      // �W�����v�E���V��



    [SerializeField, Header("Linecast�p �n�ʔ��背�C���[")]
    private LayerMask groundLayer;


    public bool isGrounded;

    public Transform bulletTran;              // �o���b�g�̐����ʒu�̔z��

    public GameObject bulletPrefab;              // �o���b�g�̃v���t�@�u

    [Header("�A�^�b�N�ҋ@����")]
    public float loadtime;

    private bool isGameOver = false; //GameOver��Ԃ̔���p�Btrue�Ȃ�Q�[���I�[�o�[�B

    private bool isFalling = false;

    [Header("������΂�����")]
    public float knockbackPower;                 // �G�ƐڐG�����ۂɐ�����΂�����

    [Header("���C��BGM")]
    [SerializeField]
    private AudioManager audioManager;              // �q�G�����L�[�ɂ��� AudioManager �X�N���v�g�̃A�^�b�`����Ă���Q�[���I�u�W�F�N�g���A�T�C��


    void Start()
    {
        // �K�v�ȃR���|�[�l���g���擾���ėp�ӂ����ϐ��ɑ��
        rb = GetComponent<Rigidbody2D>();





        anim = GetComponent<Animator>();



        scale = transform.localScale.x;

        // ���C���ȍĐ�
        StartCoroutine(audioManager.PlayBGM(0));
    }





    void Update()
    {

        ////* ��������ǉ� *////


        // �n�ʐڒn  Physics2D.Linecast���\�b�h�����s���āAGround Layer�ƃL�����̃R���C�_�[�Ƃ��ڒn���Ă��鋗�����ǂ������m�F���A�ڒn���Ă���Ȃ� true�A�ڒn���Ă��Ȃ��Ȃ� false ��߂�
        isGrounded = Physics2D.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, groundLayer);

        // Scene�r���[�� Physics2D.Linecast���\�b�h��Line��\������
        Debug.DrawLine(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, Color.red, 1.0f);



        // �W�����v
        if (Input.GetButtonDown(jump))
        {    // InputManager �� Jump �̍��ڂɓo�^����Ă���L�[���͂𔻒肷��
            Jump();
        }

        //��������I���W�i��
        // �A�^�b�N
        if (Input.GetKeyDown(KeyCode.Z) && isAttack == false)
        {    // InputManager �� Jump �̍��ڂɓo�^����Ă���L�[���͂𔻒肷��
             //�R���[�`���Ăяo��
            StartCoroutine(attack());
        }




        // �ڒn���Ă��Ȃ�(�󒆂ɂ���)�ԂŁA�������̏ꍇ
        if (isGrounded == false && rb.velocity.y < 0.15f && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump_Fall") == false)// isAttack == false  �������Ă���A�j���[�V�����̖��O���m�F���āAJump_Fall�Ƃ������O����Ȃ�������Aif�̒��g 
        {
            // �����A�j�����J��Ԃ�
            // anim.SetTrigger("Fall");  //bool�^�͑��̏������o�Ȃ����葱���ē���
            anim.SetBool("Falling", true);
            isFalling = true;
        }

        if (isGrounded == true && isFalling == true)
        {
            anim.SetBool("Falling", false);
            isFalling = false;
        }

        ////* �����܂� *////
        ///





    }

    /// <summary>
    /// �W�����v�Ƌ󒆕��V
    /// </summary>
    private void Jump()
    {
        // ��������I���W�i��
        if (isGrounded == true)
        {
            // �L�����̈ʒu��������ֈړ�������(�W�����v�E���V)
            rb.AddForce(transform.up * jumpPower);

            // Jump(Up + Mid) �A�j���[�V�������Đ�����
            anim.SetTrigger("Jump");
        }
    }

    //�R���[�`�����s
    IEnumerator attack()
    {
        isAttack = true;

        isFalling = false;
        // ��������I���W�i��

        // Attack�A�j���[�V�������Đ�����
        anim.SetTrigger("Attack");

        //0.1�b�ҋ@
        yield return new WaitForSeconds(0.15f);

        GameObject bullet = Instantiate(bulletPrefab, bulletTran);
        // Debug.Log(bullet);
        Vector3 dir = new Vector3(transform.localScale.x, 0, 0);
        bullet.GetComponent<BulletController>().Attack(dir); //F12�Ŋm�F
        bullet.transform.SetParent(null);    //�e�q�֌W������

        yield return new WaitForSeconds(loadtime);
        isAttack = false;
    }





    void FixedUpdate()
    {
        if (isGameOver == true)
        {
            return;
        }

        // �ړ�
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {

        // ����(��)�����ւ̓��͎�t
        float x = Input.GetAxis(horizontal);

        // x �̒l�� 0 �ł͂Ȃ��ꍇ = �L�[���͂�����ꍇ
        if (x != 0)
        {

            // velocity(���x)�ɐV�����l�������Ĉړ�
            rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

            // temp �ϐ��Ɍ��݂� localScale �l����
            Vector3 temp = transform.localScale;

            // ���݂̃L�[���͒l x �� temp.x �ɑ��
            temp.x = x;

            // �������ς��Ƃ��ɏ����ɂȂ�ƃL�������k��Ō����Ă��܂��̂Ő����l�ɂ���            
            if (temp.x > 0)
            {

                //  ������0�����傫����΂��ׂ�1�ɂ���
                temp.x = scale;

            }
            else
            {
                //  ������0������������΂��ׂ�-1�ɂ���
                temp.x = -scale;
            }

            // �L�����̌������ړ������ɍ��킹��
            transform.localScale = temp;





            // �ҋ@��Ԃ̃A�j���̍Đ����~�߂āA����A�j���̍Đ��ւ̑J�ڂ��s��
            anim.SetFloat("Run", 0.5f);    // ���@�ǉ�  Run �A�j���[�V�����ɑ΂��āA0.5f �̒l�����Ƃ��ēn���B�J�ڏ����� greater 0.1 �Ȃ̂ŁA0.1 �ȏ�̒l��n���Ə�������������Run �A�j���[�V�������Đ������

        }
        else
        {
            //  ���E�̓��͂��Ȃ������牡�ړ��̑��x��0�ɂ��Ă����ɒ�~����
            rb.velocity = new Vector2(0, rb.velocity.y);

            //  ����A�j���̍Đ����~�߂āA�ҋ@��Ԃ̃A�j���̍Đ��ւ̑J�ڂ��s��
            anim.SetFloat("Run", 0.0f);     // ���@�ǉ�  Run �A�j���[�V�����ɑ΂��āA0.f �̒l�����Ƃ��ēn���B�J�ڏ����� less 0.1 �Ȃ̂ŁA0.1 �ȉ��̒l��n���Ə�������������Run �A�j���[�V��������~�����


        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        // �ڐG�����R���C�_�[�����Q�[���I�u�W�F�N�g��Tag��Enemy�Ȃ� 
        if (isGameOver == false  && (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss") )
        {
           // Debug.Log("Game Over");
            GameOver();
            // �L�����ƓG�̈ʒu���狗���ƕ������v�Z
            Vector3 direction = (transform.position - col.transform.position).normalized;

            // �G�̔��Α��ɃL�����𐁂���΂�
            transform.position += direction * knockbackPower;

            anim.SetBool("Damage",true);  //�����ƌJ��Ԃ����߂ɂ�bool�^�̂��������ɂ���

        }
    }




    public void GameOver()
    {
        // ���C���ȍĐ�
        StartCoroutine(audioManager.PlayBGM(2));

        isGameOver = true;

        //Console�r���[��isGameOver�ϐ��̒l��\������B���������s������true�ƕ\�������B
        //Debug.Log(isGameOver);

        //��ʊO�ɃQ�[���I�[�o�[�\�����s��
        UIManager.DisplayGameOverInfo();
    }

}