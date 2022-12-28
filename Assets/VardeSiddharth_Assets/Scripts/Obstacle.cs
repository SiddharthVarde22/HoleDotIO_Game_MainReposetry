using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform playerRef = null;
    Rigidbody myRigidbody;

    [SerializeField]
    int pointToAdd = 3;

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
            playerRef = other.transform;
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    void CheckIfDead()
    {
        if(transform.position.y <= -10)
        {
            //Add points to the player
            if(playerRef != null)
            {
                playerRef.GetComponent<Hole>().AddPoints(pointToAdd);
            }
            Destroy(gameObject);
        }
    }
}
