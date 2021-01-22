using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMouseTranslateOnPlane : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public int playerNumber = 2;
    public float speedMouse = 0.1f;
    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {   
            float HorizontalMouvement = Input.GetAxis("Mouse X") * -speedMouse;
            float VerticalMouvement = Input.GetAxis("Mouse Y") * speedMouse;
            playerRigidbody.velocity = new Vector3(VerticalMouvement, 0, HorizontalMouvement);
        

    }
}
