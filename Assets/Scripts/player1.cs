using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{

    public int playerNumber = 1;  // Numero du joueur (Player1)
    public float speed = 6.0f;   // Vitesse du déplacement 


    private Rigidbody playerRigidbody; // Création du rigidBody de notre element


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>(); // Initialisation
    }

    // Update is called once per frame
    void Update()
    {    // Detection des bouttons
        float HorizontalMouvement = Input.GetAxis("Horizontal" + playerNumber) * speed; 
        float VerticalMouvement = Input.GetAxis("Vertical" + playerNumber) * speed;


        playerRigidbody.velocity = new Vector3(VerticalMouvement, 0,  -HorizontalMouvement); // Mouvement du joueur selon les boutton cliqué 
    }
}
