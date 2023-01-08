using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void PlayGameDevTestMap (){

        // Loads the Dev Test Dungeon.
        SceneManager.LoadScene(1);

        // Loads the next level.
        // EXAMPLE -> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    
   
}
