using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform playerRef = null;
    Hole playerHoleRefrence = null;
    //Rigidbody myRigidbody;
    float obstacleSize;

    [SerializeField]
    int pointToAdd = 3;
    [SerializeField]
    float maxDownDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = GetComponent<Rigidbody>();
        BoxCollider myBoxCollider = GetComponent<BoxCollider>();
        obstacleSize = new Vector3(myBoxCollider.size.x, 0, myBoxCollider.size.z).magnitude;


        //Debug.Log(gameObject.name + " "  + obstacleSize);
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
            
            if(playerHoleRefrence == null)
            {
                playerHoleRefrence = playerRef.GetComponent<Hole>();
                if(playerHoleRefrence == null)
                {
                    playerHoleRefrence = playerRef.parent.GetComponent<Hole>();
                }
            }

            if(playerHoleRefrence.GetPlayerSize() >= obstacleSize)
            {
                gameObject.layer = LayerMask.NameToLayer("Obstacle");
            }
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
        if(transform.position.y <= -maxDownDistance)
        {
            //Add points to the player
            if(playerRef != null)
            {
                //Hole hole;
                if (playerHoleRefrence == null)
                {
                    playerHoleRefrence = playerRef.GetComponent<Hole>();

                    if (playerHoleRefrence == null)
                    {
                        playerHoleRefrence = playerRef.parent.GetComponent<Hole>();
                    }
                }

                playerHoleRefrence.AddPoints(pointToAdd);
            }
            Destroy(gameObject);
        }
    }
}
