using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVictory : MonoBehaviour
{
    public LevelEnd levelEnd;
    public GameObject Boss;
    public ParticleSystem PS;
    public GameObject player;
    // Update is called once per frame

    void EngageWin(){
        if(Boss==null||Boss.GetComponent<Chase>().GiveEnd()){
            StartCoroutine(Winning());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("HI");
        EngageWin();
    }

    IEnumerator Winning(){
        Debug.Log("HI");
        var em = PS.emission;
        em.enabled=true;
        yield return new WaitForSeconds(5f);
        levelEnd.JumpLevel(6);
    }

}
