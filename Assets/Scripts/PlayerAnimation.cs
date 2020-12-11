using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    bool IsMoving;
    private Vector3 Vec = new Vector3(0.01f,0.01f,0.01f);
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        Blackboard.weaponAnimator.SetBool("IsMoving", IsMoving);











    }




}
