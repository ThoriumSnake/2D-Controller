using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2DController : MonoBehaviour {
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpGravity = 2.5f;
    [SerializeField] float maxFallSpeed = 10f;
    [SerializeField] bool clampFall = true;

    Rigidbody2D rb;
    float oldGravity;
    [SerializeField] float gravity = 1f;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update() {
        if (rb.velocity.y < 0)
            rb.gravityScale = fallMultiplier;
        //NOTE: If you're being "propelled" or moved upwards by an external force, pressing the jump button will increase your gravity, a way around this could be to check if you are being influenced by an external force and not increase gravity if so.
        //The way this works is: you're going up, you stop pressing the button, you have more gravity, you don't reach the original jump apex.
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = lowJumpGravity;
        else
            rb.gravityScale = gravity;

        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxFallSpeed, Mathf.Infinity));
    }

    public void Move(float movement) {
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    public void Jump(ref bool jump) {
        if (jump) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }
    }
}
