using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2DController))]
public class Player : MonoBehaviour {

    Movement2DController controller;
    void Start() {
        controller = gameObject.GetComponent<Movement2DController>();
    }

    // Update is called once per frame
    void Update() {
        controller.Move(Input.GetAxisRaw("Horizontal"));
        controller.Jump(Input.GetButtonDown("Jump"));
    }
}
