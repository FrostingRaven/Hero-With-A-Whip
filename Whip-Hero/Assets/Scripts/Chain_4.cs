using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_4 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegements = new List<RopeSegment>();
    public float ropeSegLen = 0.25f;
    public int segmentLength = 35;
    public float lineWidth = 0.1f;
    public Vector2 forceGravity = new Vector2(0f,-1.5f);
    [SerializeField] private Transform Hand;
    private EdgeCollider2D edgeCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        this.edgeCollider2D = this.GetComponent<EdgeCollider2D>();
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i =0;i<segmentLength ;i++){
            this.ropeSegements.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y-=ropeSegLen;
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
    }
    private void FixedUpdate() {
        this.SimulateRope();
    }

    private void SimulateRope(){

        //Simulations

        for (int i = 1; i<this.segmentLength;i++){
            RopeSegment firstSeg = this.ropeSegements[i];
            Vector2 velocity = firstSeg.posNow-firstSeg.posOld;
            firstSeg.posOld = firstSeg.posNow;
            firstSeg.posNow +=velocity;
            firstSeg.posNow +=forceGravity*Time.deltaTime;
            this.ropeSegements[i] = firstSeg;
        }

        //Constraints
        for (int i=0; i<50; i++){
            this.ApplyContraints();
        }
    }

    private void ApplyContraints(){
        RopeSegment firstSegm = this.ropeSegements[0];
        firstSegm.posNow = this.Hand.position;
        this.ropeSegements[0]=firstSegm;

        for(int i=0; i<this.segmentLength-1;i++){
            RopeSegment first = this.ropeSegements[i];
            RopeSegment second = this.ropeSegements[i+1];

            float dist = (first.posNow-second.posNow).magnitude;
            float error = Mathf.Abs(dist-this.ropeSegLen);
            Vector2 changerDir = Vector2.zero;

            if(dist>ropeSegLen){
                changerDir = (first.posNow-second.posNow).normalized;
            }else if(dist<ropeSegLen){
                changerDir = (second.posNow-first.posNow).normalized;
            }
            Vector2 changeAmount = changerDir*error;
            if(i!=0){
                first.posNow-= changeAmount*0.5f;
                this.ropeSegements[i]= first;
                second.posNow+=changeAmount*0.5f;
                this.ropeSegements[i+1] = second;
            }
            else{
                second.posNow += changeAmount;
                this.ropeSegements[i+1]=second;
            }
        }
    }

    private void DrawRope(){
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        List<Vector2> edgePoints = new List<Vector2>();

        for(int i = 0; i < this.segmentLength;i++){
            ropePositions[i] = this.ropeSegements[i].posNow;
            edgePoints.Add(this.ropeSegements[i].posNow);
        }
        edgeCollider2D.SetPoints(edgePoints);
        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment{
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos){
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}
