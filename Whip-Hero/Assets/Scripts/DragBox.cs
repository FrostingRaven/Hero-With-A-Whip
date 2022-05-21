using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : AttachableObject
{
    private Rigidbody2D connectedBody;
    private Transform connectedBodyPos;
    // Start is called before the first frame update
    void Start()
    {
        SetData();
    }

    // Update is called once per frame
    void Update()
    {
        if(attached){
            if (!Input.GetMouseButton(0)){
                Disattach();
            }
        }

    }
    
    private void FixedUpdate() {
        if(attached){
            Debug.Log("Hey");
            //rb2D.velocity = connectedBody.velocity.normalized*1.2f;
            transform.position = Vector2.Lerp(rb2D.position,new Vector2(connectedBodyPos.parent.position.x+connectedBody.position.x*2,rb2D.position.y),0.2f*Time.deltaTime);
            //connectedBodyPos.position = rb2D.transform.position;
        }
    }

    public override void Attach(Rigidbody2D rb)
    {
        Debug.Log("Attached");
        this.GetComponent<SpriteRenderer>().color = Color.green;
        //rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        //rb2D.velocity = new Vector2(rb.velocity.x,0f);
        //Vector2 t_y = new Vector2(rb.transform.position.x,transform.position.y);
        hj2D.enabled=true;
        hj2D.connectedBody = rb;
        connectedBody = rb;
        connectedBodyPos = rb.transform;
        //hook.GetComponent<DistanceJoint2D>().connectedBody = rb2D;
        //transform.position = Vector2.MoveTowards(transform.position,t_y,0.005f);
        attached = true;
    }
}
