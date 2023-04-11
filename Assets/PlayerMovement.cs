using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public LayerMask WhatIsGround;
    public Transform GroundCheck;

    private Rigidbody2D rb;
    private bool m_IsGrounded;
    private float m_GroundedRadiusCheck = .2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        float directionX = Input.GetAxis("Horizontal");
        Vector3 moveValue = new Vector2(directionX * MovementSpeed, rb.velocity.y);
        rb.velocity = moveValue;


        // Check IsGrounded
        m_IsGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, m_GroundedRadiusCheck, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_IsGrounded = true;
            }
        }


        // Jumping
        if (Input.GetButtonDown("Jump") && m_IsGrounded)
        {
            m_IsGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

    }
}
