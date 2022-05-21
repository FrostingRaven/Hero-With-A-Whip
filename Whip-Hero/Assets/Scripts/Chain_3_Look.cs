using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Look : MonoBehaviour
{
    public Transform parent;
    private Rigidbody2D rb;
    private HingeJoint2D hj;
    public float speed = 5f;
    public float checkRadious = 2;
    Collider2D[] objects;
    public LayerMask attachable;
    private bool attached = false;

    private void Start() {

        parent = this.transform.parent.transform;
        rb = this.GetComponent<Rigidbody2D>();
        hj = this.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached){
            objects = Physics2D.OverlapCircleAll(this.transform.position,checkRadious,attachable);
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

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,checkRadious);
    }

}
