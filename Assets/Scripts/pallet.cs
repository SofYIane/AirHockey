using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallet : MonoBehaviour
{ public delegate void GoalHandler();
    public event GoalHandler onGoal;

    public float deceleration;  // Pour diminuer la vitesse du pallet 
    public float startingPosition;
    private Rigidbody palletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        palletRigidbody = gameObject.GetComponent<Rigidbody>();  // Création du Rigidbody de notre jeu
        ResetPosition(true);  // Initialisation de la position aprés chaque but
    }
        // Update is called once per frame
        void FixedUpdate()
        {   
            palletRigidbody.velocity = new Vector3(
                palletRigidbody.velocity.x * deceleration,
                palletRigidbody.velocity.y * deceleration,
                palletRigidbody.velocity.z * deceleration
                );
        }
        private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.tag == "goal")   // S'il y'a une collision avec le gameobject portant le nom Goal (ce sont les buts)
        {
            if (onGoal != null)
            {
                onGoal();   // On appelle la fonction On goal qui est définie dans la game controller pour detecter dans quel but a été touché 
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play(); // Le son du pallet a chaque fois qu'il entre en collision avec un objet sauf les buts
        }
        if (collision.gameObject.tag == "player2goals") // S'il y'a une collision avec l'IA 
            FixedUpdate();
        }
        public void ResetPosition(bool isLeft) // Initialiser la position du pallet dans le le coté du joueur qui vient de recevoir un but
        {
            transform.position = new Vector3(
                        -startingPosition * (isLeft ? -1 : 1),
                        transform.position.y,
                        transform.position.z);
        palletRigidbody.velocity = Vector3.zero;
         
        }

          
    }

