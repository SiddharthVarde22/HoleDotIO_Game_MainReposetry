using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform playerRef = null;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRef != null)
        {
            CheckIfDead();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //myRigidbody.useGravity = true;
            //myRigidbody.isKinematic = false;
            playerRef = other.transform;
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerRef = null;
            gameObject.layer = LayerMask.NameToLayer("Default");
            //myRigidbody.useGravity = false;
            //myRigidbody.isKinematic = true;
        }
    }

    void CheckIfDead()
    {
        if(transform.position.y <= -10)
        {
            //Add points to the player
            Destroy(gameObject);
        }
    }
}
