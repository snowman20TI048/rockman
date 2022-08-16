using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;                      // �R���|�[�l���g�̎擾�p

    private float scale;                         // �����̐ݒ�ɗ��p����

    public float AttackPower;                      // �A�^�b�N��
    // Start is called before the first frame update
    void Start()
    {
        // �K�v�ȃR���|�[�l���g���擾���ėp�ӂ����ϐ��ɑ��
       // rb = GetComponent<Rigidbody2D>();



        scale = transform.localScale.x;
         //��������I���W�i��
                // �A�^�b�N
       
                   // Attack();
    }

    // Update is called once per frame
    void Update()
    {

       
        

    }

    public void Attack(Vector3 dir)
    {
        // ��������I���W�i��
        // �K�v�ȃR���|�[�l���g���擾���ėp�ӂ����ϐ��ɑ��
        rb = GetComponent<Rigidbody2D>();
        // �e�ۂ��L�����N�^�[�̌����Ă�������֗͂�������
        rb.AddForce( dir * AttackPower);

        Destroy(gameObject ,5.0f);

    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //Bullet��j��
            Destroy(gameObject);
            //Enemy��j��
            Destroy(col.gameObject);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //Bullet��j��
            Destroy(gameObject);
        }

    }


}
