using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [Header("�ړ����x")]
    public float movespeed;

    private Rigidbody2D rd;

    [SerializeField]  //��������邱�ƂŁA�h���b�O���h���b�v�ł���悤�ɂȂ�B
    public PlayerController playerController;

    private bool character_close;


    private void Start()
    {
        TryGetComponent(out rd);



    }

    private void FixedUpdate()
    {
        //rb.AddForce(-20 * dir, ForceMode2D.Impulse);
        if (transform.position.x - playerController.transform.position.x < 15.0f)
        {
            character_close = true;
        }


        if (character_close == true)
        {
            rd.velocity = new Vector3(-movespeed, rd.velocity.y, 0);
        }
    }

}
