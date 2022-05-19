using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Arm : MonoBehaviour
{
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = mousePosition;
    }

    
}
