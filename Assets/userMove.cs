using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class userMove : MonoBehaviour
{
    public Rigidbody2D rb;

    private float speed = 8f;
    private float boostTime = 0.1f;
    private Vector2 boostForce = new Vector2(50f, 0f);
    private float moveHoriz;
    private float moveVert;
    private bool boosting = false;
    private float boostTimer = 0f;

    private void Start()
    {

    }

    private void Update()
    {
        move();     //call to move function
        boost();    //call to boost function
    }

    // checks for stick input
    public void OnMove(InputValue input)    // assign movement input vectors
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveHoriz = inputVec.x;
        moveVert = inputVec.y;
    }

    // checks for boost button input
    public void OnBoost() { boosting = true; }

    // function to move the player's ship
    private void move() { rb.velocity = new Vector2((moveHoriz * speed), (moveVert * speed)); }
    
    // function to propel the player's ship forward with boost
    private void boost()
    {
        if (boosting)
        {
            boostTimer += Time.deltaTime;   // timer to control boost length

            rb.AddForce(boostForce, ForceMode2D.Force); // propel player forward with boost

            if (boostTimer > boostTime)
            {
                boosting = false;   // stop boosting
                boostTimer = 0f;    // reset timer so player can boost again
            }
        }
    }
}
