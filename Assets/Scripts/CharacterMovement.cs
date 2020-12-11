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
        Vector3 MoveDirection = transform.right*Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        CharController.Move(MoveDirection * Speed * Time.deltaTime * (Input.GetKey(KeyCode.LeftControl)?0.5f:1f));
        if (!CharController.isGrounded)
        {
            YSpeed = Mathf.Max(YSpeed - Gravity, -2f);
            CharController.Move(transform.up * YSpeed);
        }
     
        if(Input.GetKeyDown(KeyCode.Space) && CharController.isGrounded)
        {
            YSpeed = JumpForce;
            Debug.Log(YSpeed);
            CharController.Move(Vector3.up * YSpeed);
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
        


    }





}
