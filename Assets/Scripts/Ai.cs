using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{


    float speed = 5; // Vitesse de déplacement
    public int playerNumber = 2; // Numéro du joueur(Player2)
    public Transform pallet; // le pallet
    public Transform but;

    float force = 13; // impact de force au toucher du pallet
    Vector3 targetPosition; // position du mouvement du IA


    void Start()
    {
        targetPosition = transform.position; // Initialisation de la position du IA
       
    }

    void FixedUpdate()
    {
        Move(); // On appelle la méthode Move.
    }

    void Move()
    {
        if (targetPosition.z > -4 && targetPosition.z < 4) // Pour que l'IA ne sort pas du terrain (horizontalement)
        {
            if (pallet.position.x < 0)// On vérifie si le pallet se trouve du coté de l'IA 
            {
                targetPosition.x = pallet.position.x; // Mettre a jour la position du IA par rapport a X 
                targetPosition.z = pallet.position.z; // Mettre a jour la position du IA par rapport a Y
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Le IA se déplace par rapport a la position qu'on vient de mettre a jour

                
                if (targetPosition.x > pallet.position.x && pallet.position.z > 0) // Si le pallet se trouve derriere l'IA et du coté droit du terrain
                {   // IA essaye de se placer derrier le pallet
                    targetPosition.x = but.position.x - 1;
                    targetPosition.z = but.position.z - 1;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                else if (targetPosition.x > pallet.position.x && pallet.position.z < 0) // Si le pallet se trouve derriere l'IA et du coté gauche du terrain
                {   // IA essaye de se placer derrier le pallet
                    targetPosition.x = but.position.x ;
                    targetPosition.z = but.position.z ;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
            }
            else if (pallet.position.x > 0 && targetPosition.x > -6) // Si le pallet et du coté du joueur L'IA se repositionne en arriere sans sortir du terrain
            {
                targetPosition.x = but.position.x - 3;
                
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }


   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pallet") // S'il y'a une collision avec le pallet
        {
            Vector3 dir = transform.position; // Prendre la direction pour renvoyer le pallet
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(force, 0, force);

            


        }
    }
}
