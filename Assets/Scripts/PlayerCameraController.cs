using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{



    [Range(0f,10f)]
    public float CameraSensitivity;
    [Range(30f, 90f)]
    public float DefaultFOV = 60f;
    
    void Update()
    {
            Blackboard.playerCamera.transform.Rotate(Vector3.left * CameraSensitivity * Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up * CameraSensitivity * Input.GetAxis("Mouse X"));

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Blackboard.playerCamera.fieldOfView = DefaultFOV / 2;
        }
        else
        {
            Blackboard.playerCamera.fieldOfView = DefaultFOV;
        }
    }
}





