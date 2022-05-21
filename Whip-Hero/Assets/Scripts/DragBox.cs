using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : AttachableObject
{
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
    
    public override void Attach(Rigidbody2D rb)
    {
        Debug.Log("Attached");
        this.GetComponent<SpriteRenderer>().color = Color.green;
        rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        //rb2D.velocity = new Vector2(rb.velocity.x,0f);
        Debug.Log(rb2D.velocity);
        //Vector2 t_y = new Vector2(rb.transform.position.x,transform.position.y);
        hj2D.connectedBody = rb;
        //transform.position = Vector2.MoveTowards(transform.position,t_y,0.005f);
        attached = true;
    }
}
