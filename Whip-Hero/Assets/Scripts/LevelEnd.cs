using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{
    public Animator animator;
    public LayerMask End;
    private float transitionTime=1f;


    private void OnTriggerEnter2D(Collider2D other) {
        if(this.GetComponent<Collider2D>().IsTouchingLayers(End)){
            LoadNextLevel(1);
        }
    }
    public void LoadNextLevel(int v){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+v));
    }

    public void JumpLevel(int lev){
         StartCoroutine(LoadLevel(lev));
    }

    IEnumerator LoadLevel(int levelIndex){
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
