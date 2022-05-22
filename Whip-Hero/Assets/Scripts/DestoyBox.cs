using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyBox : AttachableObject
{
    Rigidbody2D connectedBody;
    private float currHP;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        currHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP<=0f){
            Destroy(rb2D.gameObject);
        }
    }

    public override void Attach(Rigidbody2D rb)
    {
        Debug.Log(rb.velocity.magnitude);
        currHP -= rb.velocity.magnitude;

        if(currHP<=0f){
            Destroy(this.gameObject);
        }
    }
}
