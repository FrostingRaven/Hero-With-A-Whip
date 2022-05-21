using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachableObject : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public HingeJoint2D hj2D;
    public bool attached=false;


    private void Start() {
        SetData();
    }

    public virtual void Attach(Rigidbody2D rb){

    }

    public virtual void Disattach(){
        hj2D.connectedBody=null;
        attached=false;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public virtual void SetData(){
        rb2D = this.GetComponent<Rigidbody2D>();
        hj2D = this.GetComponent<HingeJoint2D>();
    }

}
