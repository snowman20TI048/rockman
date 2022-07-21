using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("‘Ì—Í")]
    public float Hp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //’eŠÛ‚ð”j‰ó‚·‚é
            Destroy(col.gameObject);

            Hp--;
            if(Hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
