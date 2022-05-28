using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyBox : AttachableObject
{
    Rigidbody2D connectedBody;
    private float currHP;
    public float HP;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        currHP = HP;
        SetData();
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP<=0f){
            Destroy(rb2D.gameObject);
            Disattach();
        }
    }


    public override void Attach(Rigidbody2D rb)
    {
        currHP -= rb.velocity.magnitude;

        rb2D.AddForce(rb.velocity*speed,ForceMode2D.Impulse);
        

        if(currHP<=0f){
            Destroy(this.gameObject);
        }



    }
}
