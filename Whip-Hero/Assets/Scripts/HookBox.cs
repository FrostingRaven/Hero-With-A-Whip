using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBox : AttachableObject
{
    public DistanceJoint2D ds2D;
    private Rigidbody2D connectedBody;
    private Transform connectedBodyPos;

    // Start is called before the first frame update
    void Start()
    {
        ds2D = this.GetComponent<DistanceJoint2D>();
        SetData();
    }

    // Update is called once per frame
    void Update()
    {

    }


    override public void Attach(Rigidbody2D rb){
        hj2D.enabled=true;
        hj2D.connectedBody = rb;
        ds2D.enabled=true;
        connectedBody = rb;
        connectedBodyPos = rb.transform;
        attached = true;
        ds2D.connectedBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        hook = connectedBody.GetComponent<Chain_3_Look>().parent.gameObject;
        ds2D.connectedAnchor=-1*hook.transform.position;
    }
}
