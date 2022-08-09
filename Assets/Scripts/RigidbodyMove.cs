using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [Header("ˆÚ“®‘¬“x")]
    public float movespeed;

    private Rigidbody2D rd;

    private void Start()
    {
        TryGetComponent(out rd);



    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector3(-movespeed, rd.velocity.y, 0);
    }

}
