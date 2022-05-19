using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_1 : MonoBehaviour
{


    public Rigidbody2D rb2D;
    public Camera cam;
    public Transform parent;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKey(KeyCode.Mouse0)){
            rb2D.position = mousePos;
        }
    }

    private void FixedUpdate() {
        Vector2 lookat = mousePos - rb2D.position;
        float angle = Mathf.Atan2(lookat.y,lookat.x)*Mathf.Rad2Deg-90f;
        rb2D.rotation = angle;
    }
}
