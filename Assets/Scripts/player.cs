using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int playerNumber;
    public float speed = 1.0f;


    private Rigidbody playerRigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   // Mouvement du joueur selon les boutton cliqué 
        // J'ai configuré dans le menu Input Manager que :
        // Horziontal1 =  Gauche et Droite
        // Vertical1   =  Haut et Bas
        // Horziontal2 = Q et D 
        // Vertical2   = Z et S
        // Donc le joueur 1 aura Horizontal+1 et vertical+1 et le joueur 2 aura Horizontal+2 et vertical+2

        float HorizontalMouvement = Input.GetAxis("Horizontal"+playerNumber) * speed; // 
        float VerticalMouvement   = Input.GetAxis("Vertical"+playerNumber) * speed; // 


        playerRigidbody.velocity = new Vector3(HorizontalMouvement, 0, VerticalMouvement);
    }
}
