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
        if(Boss!=null){
            StartCoroutine(Winning());
        }
    }

    IEnumerator Winning(){
        var em = PS.emission;
        em.enabled=true;
        player.GetComponent<Animator>().SetBool("Win",true);
        yield return new WaitForSeconds(5f);
        levelEnd.JumpLevel(6);
    }

}
