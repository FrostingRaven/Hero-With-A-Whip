using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Last : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mousePosB;
    public float speed = 1.5f;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        mousePosB = Input.mousePosition;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    public Vector3 mouseD{
        get{
            return Input.mousePosition - mousePosB;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = mouseD/2.2f;
        mousePosB = Input.mousePosition;
        //try something with how the mouse moves. if it goes up, then make the chain go up
        //it if does to the left make it so the motors of the chains engage and rotate in the
        //right directions.
    }
}
