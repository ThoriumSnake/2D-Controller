using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2DController))]
public class Player : MonoBehaviour {

    Movement2DController controller;
    [System.NonSerialized] public float horDirection;
    [System.NonSerialized] public bool jump;
    [System.NonSerialized] public float jumpPressedTime;

    [SerializeField] float WalkMultiplier = 0.5f;

    void Start() {
        controller = gameObject.GetComponent<Movement2DController>();
    }

    // Update is called once per frame
    void Update() {
        horDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Walk"))
            horDirection *= WalkMultiplier;

        //Update is called more than FixedUpdate, so the jump variable can't be dependent on whether the user pressed jump on a specific frame
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            jumpPressedTime = Time.time;
        }
    }

    void FixedUpdate() {
        controller.Move(horDirection);
        controller.Jump(ref jump, ref jumpPressedTime);
    }
}
