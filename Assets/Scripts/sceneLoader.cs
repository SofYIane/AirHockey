using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
   public void LoadaGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Pour charger la scene du J1 vs J2 (Clavier)
    }
    public void LoadaGameMouse()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Pour charger la scene du J1 vs J2(Souris)
    }
    public void LoadaGameIA()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); // Pour charger la scene du J1 vs IA
    }
    public void QuitGame() // Quitter le jeu
    {
        Application.Quit();
        Debug.Log("Quit !");
    }
}
