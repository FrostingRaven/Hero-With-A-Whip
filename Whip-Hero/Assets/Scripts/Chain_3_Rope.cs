using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public Transform Hand;
    public GameObject[] prefabRopeSegs;
    public int numLinks = 5;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Hand.position;
        GenerateRope();
    }

    private void Update() {
        hook.position = Hand.position;
        this.transform.position = Hand.position;
    }

    void GenerateRope(){
        hook.position = Hand.position;
        Rigidbody2D prevBond = hook;
        for (int i =0; i<numLinks;i++){
            int index = Random.Range(0,prefabRopeSegs.Length);
            GameObject newSeg = Instantiate(prefabRopeSegs[index]);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBond;

            prevBond = newSeg.GetComponent<Rigidbody2D>();
            if (i==0){
                hj.useLimits=false;
            }/*
            if (i==numLinks-1||i==0){
                newSeg.GetComponent<Chain_3_Look>().enabled=true;
            }
            /*
            if (i==numLinks-1){
                hook.GetComponent<DistanceJoint2D>().connectedBody = newSeg.GetComponent<Rigidbody2D>(); 
            }
            */
        }
        this.GetComponent<Chain_3_Test>().SetKids();
    }
}
