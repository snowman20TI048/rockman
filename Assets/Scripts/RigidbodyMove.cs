using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [Header("移動速度")]
    public float movespeed;

    private Rigidbody2D rd;

    [SerializeField]  //これをつけることで、ドラッグ＆ドロップできるようになる。
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
