using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static bool GameIsPaused;
    public void Start()
    {
        GameIsPaused = false;
    }
    // Start is called before the first frame update
    public void Resume()   // Continuer la partie 
    {
        PauseMenuUI.SetActive(false);   
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Restart()    // Redemarrer la partie 
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    
    public void QuitGame()  // Quitter le jeu 
    {
        Application.Quit();
        Debug.Log("Quit !");  
    }
}
