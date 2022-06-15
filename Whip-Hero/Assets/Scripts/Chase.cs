using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform Startpoint;
    public Transform[] path;
    private int currentProgress=0;
    public float speed;
    private float WPradius = 1;
    public GameObject obsticle; 
    public GameObject player;
    public LayerMask p;
    private bool engageChase=false;
    public bool end=false;

    // Update is called once per frame
    void Update()
    {
        if(!engageChase){
            engageChase=Physics2D.OverlapCircle(Startpoint.position,10f,p);
        }
        if(engageChase){
            StartChase();
        }
        if((obsticle==null||!obsticle.activeSelf)&&path[path.Length-1]!=path[path.Length-2]){
            EndChase();
        }
    }

    private void EndChase(){
        path[path.Length-1]=path[path.Length-2];
        end=true;
    }

    public bool GiveEnd(){
        return end;
    }

    void StartChase(){
        if(Vector2.Distance(path[currentProgress].position,transform.position)<WPradius){
            currentProgress++;
        }
        if(currentProgress==path.Length){
            engageChase=false;
            Destroy(this.gameObject);
            return;
        }
        transform.position=Vector2.MoveTowards(transform.position,path[currentProgress].position,Time.deltaTime*speed);
    }
    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(Startpoint.position,10f);
    }
}
