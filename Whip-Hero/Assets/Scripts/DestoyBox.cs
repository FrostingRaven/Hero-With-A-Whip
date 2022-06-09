using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyBox : AttachableObject
{
    Rigidbody2D connectedBody;
    private float currHP;
    public Sprite desSprite;
    private SpriteRenderer sp;
    public float HP;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        currHP = HP;
        SetData();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Attach(Rigidbody2D rb)
    {
        currHP -= rb.velocity.magnitude;

        rb2D.AddForce(rb.velocity*speed,ForceMode2D.Impulse);
        

        if(currHP<=0f){
            if(desSprite==null){
                Destroy(rb2D.gameObject);
            }
            else{
                sp.sprite = desSprite;
                rb2D.gameObject.layer = 12;
            }
            Disattach();
        }



    }
}
