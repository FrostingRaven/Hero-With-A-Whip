using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HP : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    [SerializeField] private Animator animator;
    public Slider hpbar;
    public GameObject DeadScreen;
    public float currHP;
    public LayerMask chase;
    public Transform pointofDamage;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        hpbar.maxValue = MaxHP;
        hpbar.value = MaxHP;
        currHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("Damaged");
        if(currHP<=0){
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (this.GetComponent<BoxCollider2D>().IsTouchingLayers(chase)){
            TakeDamage(100f);
        }    
        if (this.GetComponent<CircleCollider2D>().IsTouchingLayers(chase)){
            TakeDamage(100f);
        }  
    }

    public void Death(){
        animator.SetTrigger("Death");
        Time.timeScale=0f;
        DeadScreen.SetActive(true);

    }

    public void TakeDamage(float damage){
        currHP-=damage;
        animator.SetTrigger("Damaged");
        hpbar.value=currHP;
    }
}
