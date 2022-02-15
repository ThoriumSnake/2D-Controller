using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2DController))]
public class Player : MonoBehaviour {

    Movement2DController controller;
    float horizontalMovement;
    bool jump;

    void Start() {
        controller = gameObject.GetComponent<Movement2DController>();
    }

    // Update is called once per frame
    void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        //Update is called more than FixedUpdate, so the jump variable can't be dependent on whether the user pressed jump on a specific frame
        if (Input.GetButtonDown("Jump"))
            jump = true;

        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
    }

    void FixedUpdate() {
        controller.Move(horizontalMovement);
        controller.Jump(ref jump);
        //Debug.Log("jump: " + jump);
    }
}
