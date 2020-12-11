using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrencer : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    GameObject cameraObject;
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    Animator weaponAnimator;
    private void Start() {
        Blackboard.playerObject = playerObject;
        Blackboard.cameraObject = cameraObject;
        Blackboard.playerCamera = playerCamera;
        Blackboard.weaponAnimator = weaponAnimator;
    }
}

public static class Blackboard {
    public static GameObject playerObject;
    public static GameObject cameraObject;
    public static Camera playerCamera;
    public static Animator weaponAnimator;
}

