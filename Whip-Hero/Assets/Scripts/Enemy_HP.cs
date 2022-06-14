using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HP : MonoBehaviour
{

    [SerializeField] private float maxHP;
    public float currHP=1f;
    public EnemyHPBar HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        currHP=maxHP;
        HealthBar.SetHP(currHP,maxHP);
    }

    // Update is called once per frame

    public void Death(){
        this.GetComponent<Rigidbody2D>().freezeRotation=false;
        this.gameObject.layer = 11;
        this.GetComponent<Collider2D>().isTrigger=true;
        this.GetComponent<AIPAtrool>().enabled=false;
        this.enabled=false;
    }

    public void Attack(Rigidbody2D rb, float flatDamage){
        currHP-=rb.velocity.magnitude+flatDamage;
        HealthBar.SetHP(currHP,maxHP);
        if(currHP<=0){
            Death();
        }
    }
}
