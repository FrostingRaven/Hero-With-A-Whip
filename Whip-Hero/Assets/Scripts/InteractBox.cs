using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBox : AttachableObject
{
    Rigidbody2D rb;
    public GameObject ConnectedObject;
    private bool fliping;
    // Start is called before the first frame update
    void Start()
    {
        fliping=true;
        SetData();
    }

    void Update(){
        if(attached){
            if (!Input.GetMouseButton(0)||Vector2.Distance(ConnectedObject.transform.position,this.transform.position)>1.5f){
                Disattach();
            }
        }
    }

    public override void Attach(Rigidbody2D rb)
    {
        ConnectedObject.GetComponent<InteractConnected>().Engage();
        this.gameObject.GetComponent<SpriteRenderer>().flipX=fliping;
        fliping=!fliping;
        //This is to be made better with more other interactions for now we are going to do something
        //simple and local
        //ConnectedObject.Engage();
    }
}
