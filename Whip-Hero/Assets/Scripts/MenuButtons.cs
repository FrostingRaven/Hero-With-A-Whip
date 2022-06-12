using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenu;
    public GameObject MouseFollower;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        MouseFollower.GetComponent<Chain_3_Arm>().enabled=true;
        PauseMenu.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    public void QuitToMain(){
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }
    public void Pause(){
        MouseFollower.GetComponent<Chain_3_Arm>().enabled=false;
        PauseMenu.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
    }
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    
    }

    public bool PauseState(){
        return GameIsPaused;
    }
}
