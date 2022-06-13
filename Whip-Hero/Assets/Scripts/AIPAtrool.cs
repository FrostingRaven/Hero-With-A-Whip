using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPAtrool : MonoBehaviour
{
    private bool mustFlip;
    public float WalkSpoeed;
    public bool mustPatrool;
    public Rigidbody2D rb2d;
    public Transform GroundCheckPosition;
    public LayerMask GroundLayer;
    public Collider2D BodyCollider;
    public Transform Player;
    public Transform ShootPosition;
    public float range;
    private float distToPLayer;
    public GameObject Bullet;
    private bool IsItShooting=false;

    public float shootingRateInSeconds, BulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        mustPatrool = true;
    }

    void patrol()
    {
        if (mustFlip || BodyCollider.IsTouchingLayers(GroundLayer))
        {
            Flip();
        }

        rb2d.velocity = new Vector2(WalkSpoeed * Time.fixedDeltaTime, rb2d.velocity.y);

    }
    private void FixedUpdate()
    {
        if (mustPatrool)
        {
            mustFlip = !Physics2D.OverlapCircle(GroundCheckPosition.position, 0.1f, GroundLayer);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (mustPatrool)
        {

            patrol();
        }
        distToPLayer = Vector2.Distance(transform.position, Player.position);
        if (distToPLayer <= range)
        {
            if (Player.position.x > transform.position.x && transform.localScale.x < 0)
            {
                Flip();
            }

            if (Player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrool = false;
            rb2d.velocity = Vector2.zero;
            if (!IsItShooting)
            {
                StartCoroutine(Shoot());
            }
        }else mustPatrool = true;
    }

   

    void Flip()
    {
        mustPatrool = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpoeed *= -1;
        mustPatrool = true;
    }
    IEnumerator Shoot()
    {
        IsItShooting = true;
        yield return new WaitForSeconds(shootingRateInSeconds);
        GameObject newBullets = Instantiate(Bullet, ShootPosition.position  ,Quaternion.identity);
        newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed * WalkSpoeed * Time.fixedDeltaTime, 0f);
        IsItShooting = false;


    }
}
