using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenu;
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
        PauseMenu.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    public void QuitToMain(){
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }
    public void Pause(){
        PauseMenu.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
    }
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    
    }
}
