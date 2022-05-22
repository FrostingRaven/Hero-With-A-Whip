using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBox : AttachableObject
{
    Rigidbody2D rb;
    public GameObject ConnectedObject;
    private GameObject PrevState;
    private bool engaged=false;
    // Start is called before the first frame update
    void Start()
    {
        PrevState = ConnectedObject;
    }


    public override void Attach(Rigidbody2D rb)
    {
        //To be removed
        if(!engaged){
            ConnectedObject.GetComponent<SpriteRenderer>().color=Color.black;
            engaged=!engaged;
        }
        else{
            ConnectedObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            engaged=!engaged;
        }
        //This is to be made better with more other interactions for now we are going to do something
        //simple and local
        //ConnectedObject.Engage();
    }
}
