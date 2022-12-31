using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 initialCameraRotation = new Vector3(45f, 0, 0);
    [SerializeField]
    Vector3 offsetFromPlayer = new Vector3(0, 10, -10);
    [SerializeField]
    float cameraFollowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(playerTransform == null)
        {
            Debug.Log("Player transform is missing");
        }

        transform.rotation = Quaternion.Euler(initialCameraRotation);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            playerTransform.position + offsetFromPlayer, cameraFollowSpeed * Time.deltaTime);
    }
}
