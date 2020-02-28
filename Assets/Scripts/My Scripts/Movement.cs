using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Flip(int dir)
    {
        transform.localScale = new Vector2(dir * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    // Update is called once per frame
    private void Update()
    {
        this.handleMovement();
        transform.rotation = Quaternion.identity;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            this.Flip(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
            this.Flip(1);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }

        animator.SetFloat("speed", Mathf.Abs(rigidbody2d.velocity.x));
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
}

