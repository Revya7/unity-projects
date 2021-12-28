using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // config
    [SerializeField] float runSpeed = 10f;


    // state
    bool isAlive = true;

    // cache
    Rigidbody2D myRigidBody2D;
    Animator myAnimator;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * runSpeed;
        Vector2 runningVector = new Vector2(deltaX, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = runningVector;
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;  // if hor speed aboslute is > 0
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody2D.velocity.x), 1f); // y scale is 1f by deault so keep it
        }

        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }
}
