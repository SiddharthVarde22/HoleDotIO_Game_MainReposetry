using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    Joystick joystickInput;
    [SerializeField]
    float playerMoveSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        if(joystickInput == null)
        {
            Debug.Log("Missing Joystick for input");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((transform.right * joystickInput.Horizontal)
            + (transform.forward * joystickInput.Vertical)).normalized * playerMoveSpeed * Time.deltaTime;
    }
}
