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
        // �e�ۂ�������ֈړ�������(�W�����v�E���V)
        rb.AddForce( dir * AttackPower);

        Destroy(gameObject ,5.0f);

    }


}
