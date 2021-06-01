using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //public Animator anim;

    [Range(0,100)]public float runSpeed = 40f;

    float xMovement = 0f;
    bool jump = false;
    
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(xMovement * Time.fixedDeltaTime, jump);
        if(jump)
        {
            //anim.SetTrigger("Jump");   
        }
        
        jump = false;
    }
}
