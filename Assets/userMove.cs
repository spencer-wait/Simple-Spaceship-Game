using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class userMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float originalSpeed = 8f;
    public float boostTime = 3f;

    private float boostSpeed;   // boost power will be double the normal speed
    private bool boosting = false;
    private float moveHoriz;
    private float moveVert;
    private float rotate;

    private void Start()
    {
        boostSpeed = originalSpeed * 2; // assign boost to be double the normal speed
    }

    private void Update()
    {
        
        if (boosting)
        {
            StartCoroutine(boostShip());
        }
        else
        {
            rb.velocity = new Vector2((moveHoriz * originalSpeed), (moveVert * originalSpeed));
        }
    }

    public void OnMove(InputValue input)    // assign movement input vectors
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveHoriz = inputVec.x;
        moveVert = inputVec.y;
    }

    public void OnBoost(InputValue input) { boosting = true; }

    IEnumerator boostShip() // allows for boosting while using the WaitForSeconds() function to limit boost time
    {
        // move player based on stick input times speed variable
        rb.velocity = new Vector2((moveHoriz * boostSpeed), (moveVert * originalSpeed));
        yield return new WaitForSeconds(boostTime);
        boosting = false;
    }
}
