using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("�ړ����x")]
    public float movespeed;

    [SerializeField]  //��������邱�ƂŁA�h���b�O���h���b�v�ł���悤�ɂȂ�B
    public PlayerController playerController;

    private bool character_close;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - playerController.transform.position.x < 15.0f)
        {
            character_close = true;
        }


        if (character_close == true)
        {
            //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�̈ʒu�����X�V���Ĉړ�������
            transform.position += new Vector3(-movespeed, 0, 0);
        }

       
     
        //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���Q�[����ʂɉf��Ȃ��ʒu�܂ňړ�������
    /*    if(transform.position.x <= -14.0f)
        {
            //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g��j��
            Destroy(gameObject);
        }

    */
    }
}
