using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : AttachableObject
{
    private Rigidbody2D connectedBody;
    private Transform connectedBodyPos;
    public bool released=false;
    Vector3 mousePos;
    Vector3 mousePosB;
    // Start is called before the first frame update
    void Start()
    {
        mousePosB = Input.mousePosition;
        SetData();
    }

    public Vector3 mouseD{
        get{
            return Input.mousePosition - mousePosB;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attached){
            if (!Input.GetMouseButton(0)){
                rb2D.constraints &= RigidbodyConstraints2D.FreezePositionX;
                rb2D.mass=50;
                Disattach();
                released=true;
            }
        }

    }
    
    private void FixedUpdate() {
        if(attached){
            Debug.Log("Hey");
            Vector2 localV = mouseD;
            //Vector2 localV = connectedBodyPos.parent.transform.InverseTransformDirection(connectedBody.velocity);
            localV.y=rb2D.velocity.y;
            rb2D.velocity = localV*2f*Time.deltaTime;
            //localV.y=rb2D.velocity.y;
            //rb2D.velocity = new Vector2(mouseD.x*2f,rb2D.velocity.y)*Time.deltaTime;
            mousePosB = Input.mousePosition;
            rb2D.mass=15;
            //transform.position = Vector2.Lerp(rb2D.position,new Vector2(connectedBodyPos.parent.position.x+connectedBody.position.x*2,rb2D.position.y),0.2f*Time.deltaTime);
            connectedBody.position=new Vector2(rb2D.position.x,rb2D.position.y);
            //Disattach();
        }
        if(released){
            rb2D.velocity=rb2D.velocity*2f;
            released=false;
            rb2D.constraints &= RigidbodyConstraints2D.FreezePositionX;
            rb2D.mass=50;
        }
    }

    public override void Attach(Rigidbody2D rb)
    {
        //Debug.Log("Attached");
        rb2D.mass=15;
        //rb2D.velocity = new Vector2(rb.velocity.x,0f);
        //Vector2 t_y = new Vector2(rb.transform.position.x,transform.position.y);
        //hj2D.enabled=true;
        //hj2D.connectedBody = rb;
        rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        connectedBody = rb;
        connectedBodyPos = rb.transform;
        //hj2D.anchor=connectedBodyPos.position;
        //hook.GetComponent<DistanceJoint2D>().connectedBody = rb2D;
        //transform.position = Vector2.MoveTowards(transform.position,t_y,0.005f);
        attached = true;
    }
}
