using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float direTime, damage;
    public  int BulletSpeed;
    public Rigidbody2D rb;
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right*BulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        Player_HP playerhp = coll.gameObject.GetComponent<Player_HP>();
        if(playerhp!=null){
            playerhp.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(direTime);
        Destroy(gameObject);
    }
}
