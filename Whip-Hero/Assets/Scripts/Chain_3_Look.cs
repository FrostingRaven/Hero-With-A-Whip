using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Look : MonoBehaviour
{
    public Transform parent;
    private Rigidbody2D rb;
    private HingeJoint2D hj;
    public float speed = 5f;

    private void Start() {
        parent = this.transform.parent.transform;
        rb = this.GetComponent<Rigidbody2D>();
        hj = this.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
