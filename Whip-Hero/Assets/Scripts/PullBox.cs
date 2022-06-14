using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBox : AttachableObject
{
    private Rigidbody2D connectedBody;
    private Transform connectedBodyPos;
    public bool released=false;
    // Start is called before the first frame update
    void Start()
    {
        SetData();
    }

    // Update is called once per frame
    void Update()
    {
        if(attached){
            if (!Input.GetMouseButton(0)||Vector2.Distance(connectedBodyPos.position,this.transform.position)>1.5f){
                Disattach();
                released=true;
            }
        }

    }
    
    private void FixedUpdate() {
        if(attached){
            connectedBodyPos.position=rb2D.transform.position;
        }
        if(released){
            rb2D.velocity=rb2D.velocity*0.5f;
            released=false;
            Disattach();
        }
    }

    public override void Attach(Rigidbody2D rb)
    {
        hj2D.enabled=true;
        hj2D.connectedBody = rb;
        connectedBody = rb;
        connectedBodyPos = rb.transform;
        attached = true;
    }
}
