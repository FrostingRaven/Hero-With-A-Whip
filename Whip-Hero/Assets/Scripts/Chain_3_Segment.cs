using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Segment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;
    // Start is called before the first frame update
    void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        Chain_3_Segment aboveSegment = connectedAbove.GetComponent<Chain_3_Segment>();
        if(aboveSegment !=null){
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0,spriteBottom*-10);
        }
        else{
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0,0);
        }
    }
}
