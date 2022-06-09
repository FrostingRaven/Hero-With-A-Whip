using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractConnected : MonoBehaviour
{
    public Animator animator;
    public bool Press=false;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Press",Press);
    }

    public void Engage(){
        if(Press){
            animator.SetBool("Press",Press);
            Press=!Press;
        }
        else{
            animator.SetBool("Press",Press);
            Press=!Press;
        }
    }
}
