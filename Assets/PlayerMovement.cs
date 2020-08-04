using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 1000f;
    bool jump = false;
    float horizontalMove = 0f;

    // Update is called once per frame to detect input
    void Update()
    {

        //Value between -1 and 1 that changes on input
        // Left/A  = -1
        // Right/D = (+)1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        //For button PRESS
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        //To get shit working with button RELEASE, use >>GetButtonUp<<
        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //} else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}
    }

    //Uses Update to apply input to charcter
    void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    //This requires that the object to be collided WITH has it's own tag, seen in the if-statement.
    //The object also needs to be a collider, and have the "Is Trigger" flagged set to ON.
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}