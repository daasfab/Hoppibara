using System.Collections;  //code for Hoppibara by @daasfab in github!
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //getting reference of our player obj to apply forces to it when specific keys inputs are detected!
    [SerializeField] private float jumpForce = 10f; //the value will be changed in the inspector menu (Unity) to the value that will better suit the gameplay
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform GFX; //will transform the dimensions of the capi when its crouching

    [SerializeField] private Transform feetPos;  //sends raycast of capi's feet to see if its isGrounded or not
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private float crouchHeight = 0.1f;

    private bool isGrounded = false; //checks if player is grounded (for jumping)
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer); //returns True or False depending on if capi is touching ground

        #region JUMP

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
        #endregion 

        #region CROUCH

        if (isGrounded && Input.GetButton("Crouch"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);

            if (isJumping)
            {
                GFX.localScale = new Vector3(GFX.localScale.x, 0.11612f, GFX.localScale.z);
            }
        }

        if (Input.GetButtonUp("Crouch"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 0.11612f, GFX.localScale.z);
        }
        #endregion
    }

}
