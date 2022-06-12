using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_3_Test : MonoBehaviour
{
    Vector2 mousePosition;
    Vector2 direction;
    public GameObject Pauser;
    public float speed = 5f;
    public List<GameObject> children;
    public float scale = 1f;
    Quaternion rotate;
    private bool gamePause;

    public void SetKids(){
        foreach (Transform child in transform){
            if (child.gameObject.GetComponentInChildren<Chain_3_Look>()!=null)
                children.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gamePause = Pauser.GetComponent<MenuButtons>().PauseState();
        if(!gamePause){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            rotate = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate,speed);
        }
    }

    private void FixedUpdate() {
        float down = scale;
        foreach(GameObject chain in children){
            chain.GetComponent<Rigidbody2D>().velocity*=down;
            down+=0.001f;
        }
    }
}
