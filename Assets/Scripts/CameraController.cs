using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Toko_Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        if(playerPos.x < 0) 
        { 
            playerPos.x = 0;
        }
        transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
    }
}
