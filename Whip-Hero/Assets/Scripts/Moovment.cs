using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovment : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingForce = 10f;
    private bool isFaceingRight = true;
    public GameObject whip;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
        if(rb2d.velocity.magnitude!=0){
            animator.SetBool("isRunning",true);
        }   
        else{
            animator.SetBool("isRunning",false);
        }
        Flip();
    }
    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFaceingRight && horizontal <0f || !isFaceingRight && horizontal > 0f)
        {
            
            isFaceingRight = !isFaceingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            localScale = whip.transform.localPosition;
            localScale.y *= -1f;
            whip.transform.localPosition = localScale;
            whip.GetComponent<SpriteRenderer>().flipY=!isFaceingRight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded()){
            animator.ResetTrigger("Jump");
            animator.SetBool("isJumping",false);
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping",true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingForce);
        }
    //    if (Input.GetButton("Jump") && rb2d.velocity.x > 0f)
      //      {
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        
          //  }
    }
}
