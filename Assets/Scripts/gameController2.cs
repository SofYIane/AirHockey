using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController2 : MonoBehaviour
{
    public restartScript pauseMenu;
    public pallet pallet;
    private int score1;
    private int score2;
    public Text scoreText;
    private bool isGameOver;
    private float resetTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        pallet.onGoal += OnGoal; // On incrémente a chaque but
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)   // Si la partie se termine alors
        {
            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                SceneManager.LoadScene("AirHockeyIA"); // Si la partie est finie est le joueur clique sur Restart
            }
        }
    }
    void OnGoal()   // Pour detecter s'il y'a un but
    {

        if (pallet.transform.position.x > 0)  // Si le pallet est du coté du player 2 alors 
        {
            score1++; // on ajoute un but au score du player 1
            pallet.ResetPosition(true);   // On repositionne le pallet du coté du player 2
        }
        else  // Si le pallet est du coté du player 1 alors 
        {
            score2++; // on ajoute un but au score du player 2
            pallet.ResetPosition(false); // On repositionne le pallet du coté du player 1
        }
        scoreText.text = score1 + " : " + score2;

        if (score1 == 3) // Si le score est de 3 pour le player 2 alors 
        {
            scoreText.text = "Player 2 wins !!";    // Le player 2 a gagné 
            pallet.gameObject.SetActive(false);
            isGameOver = true; // La partie est finie
            pauseMenu.Restart(); // Affiche le menu
        }
        else if (score2 == 3) // Si le score est de 3 pour le player 1 alors 
        {
            scoreText.text = "Player 1 wins !!"; // Le player 1 a gagné 
            pallet.gameObject.SetActive(false);
            isGameOver = true; // La partie est finie
            pauseMenu.Restart(); // Affiche le menu

        }
    }
}