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

    public float shootingRateInSeconds;
    [SerializeField] private Animator animator;
    
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
        animator.SetBool("isMoving",true);
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
            if (Player.position.x > transform.position.x && transform.rotation.y < 0)
            {
                Flip();
            }

            if (Player.position.x < transform.position.x && transform.rotation.y > 0)
            {
                Flip();
            }
            mustPatrool = false;
            rb2d.velocity = Vector2.zero;
            if (!IsItShooting)
            {
                animator.SetBool("isMoving",false);
                animator.SetTrigger("Attack");
                StartCoroutine(Shoot());
            }
        }else mustPatrool = true;
    }

   

    void Flip()
    {
        mustPatrool = false;
        transform.Rotate(0f,180f,0f);
        WalkSpoeed *= -1;
        mustFlip=true;
        animator.SetBool("isMoving",false);
    }
    IEnumerator Shoot()
    {
        animator.SetTrigger("Attack");
        IsItShooting = true;
        yield return new WaitForSeconds(shootingRateInSeconds);
        GameObject newBullets = Instantiate(Bullet, ShootPosition.position  ,ShootPosition.rotation);
        IsItShooting = false;

    }
}
