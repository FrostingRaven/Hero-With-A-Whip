using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Look : MonoBehaviour
{
    public Transform parent;
    private Rigidbody2D rb;
    private HingeJoint2D hj;
    private DistanceJoint2D dj;
    public float speed = 5f;
    public float checkRadious = 2;
    public Transform point;
    Collider2D[] objects;
    public LayerMask attachable;
    private bool attached = false;

    private void Start() {

        parent = this.transform.parent.transform;
        rb = this.GetComponent<Rigidbody2D>();
        hj = this.GetComponent<HingeJoint2D>();
        dj = this.GetComponent<DistanceJoint2D>();
        dj.connectedBody = this.GetComponent<Chain_3_Segment>().connectedAbove.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached){
            objects = Physics2D.OverlapCircleAll(point.position,checkRadious,attachable);
            if(Input.GetMouseButton(0)){
                foreach(Collider2D obj in objects){
                    obj.GetComponent<AttachableObject>().Attach(rb);
                    attached = true;
                }
            }
        }
        if(!Input.GetMouseButton(0)){
            attached = false;
        }
    }


}
