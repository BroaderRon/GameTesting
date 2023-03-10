using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour{

    public static bool GameIsPaused = false;
    public GameObject startMenuUI;

    // Update is called once per frame
    void update (){

        if (Input.GetKeyDown("escape")){

            if (GameIsPaused){

                Resume();

            }
            else{

                Pause();

            }
        }
    }

    public void Resume (){
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause (){
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Debug.Log ("Loading menu...");
    }

    public void QuitGame(){
        Debug.Log ("Exited Appplication!");
        Application.Quit();
    }
   
}
