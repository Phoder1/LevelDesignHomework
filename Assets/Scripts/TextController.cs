using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private float addDegreesX = 0f;
    [SerializeField]
    private float addDegreesY = 0f;
    [SerializeField]
    private float addDegreesZ = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Blackboard.cameraObject.transform.position, Vector3.up) * Quaternion.Euler(addDegreesX,addDegreesY,addDegreesZ);
    }
}
