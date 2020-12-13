using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController CharController;
    public float Speed = 5;
    public float Gravity;
    public float JumpForce;
    private float YSpeed = 0f;

    public float DefaultHeight;
    public float DefaultCrouch;

    bool crouching = false;

    [SerializeField]
    private GameObject PlayerCameraObj;

    [SerializeField]
    GameObject canvas;



    // Start is called before the first frame update
    void Start()
    {
        CharController = this.gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            canvas.SetActive(!canvas.activeSelf);
        }

        Vector3 MoveDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        MoveDirection *= (Input.GetKey(KeyCode.LeftControl) ? 0.5f : 1f) * Speed;

        Debug.Log("grounded: " + CharController.isGrounded);
        Debug.Log("Space: " + Input.GetKeyDown(KeyCode.Space));

        if ( !CharController.isGrounded)
        {
            Debug.Log("gravity");
            YSpeed = Mathf.Max(YSpeed - Gravity * Time.deltaTime, -100f);

            MoveDirection += transform.up * YSpeed;
        }else if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");  
            YSpeed = JumpForce;
            MoveDirection += transform.up * YSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerCameraObj.transform.localPosition = Vector3.up * (DefaultCrouch / 2);
            CharController.height = DefaultCrouch;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            PlayerCameraObj.transform.localPosition = Vector3.up * (DefaultHeight / 2);
            CharController.height = DefaultHeight;
        }

        CharController.Move(MoveDirection  * Time.deltaTime);


    }





}
