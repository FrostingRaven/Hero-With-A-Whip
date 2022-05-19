using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_2_Body : MonoBehaviour
{
    public int lenght;
    public LineRenderer lineRenderer;
    public Vector3[] segementPos;
    public Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailspeed; 

    private void Start() {
        lineRenderer.positionCount = lenght;
        segementPos = new Vector3[lenght];
        segmentV = new Vector3[lenght];
    }

    private void Update() {
        segementPos[0] = targetDir.position;
        for(int i=1; i<segementPos.Length;i++){
            segementPos[i] = Vector3.SmoothDamp(segementPos[i],segementPos[i-1]+targetDir.right*targetDist,ref segmentV[i],smoothSpeed+i/trailspeed);
        }
        lineRenderer.SetPositions(segementPos);
    }
}
