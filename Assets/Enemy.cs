using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allow enemy to be killed and move around two points
/// 
/// To allow enemy to move around the two points:
/// 1. Put the First and Second Point to where you want it to move
/// 
/// Note: This script ignores gravity and can phase through objects
/// </summary>
public class Enemy : MonoBehaviour
{
    public float MoveSpeed;
    public Transform FirstPoint;
    public Transform SecondPoint;
    public bool IsLookingRight;

    private Vector3 CurrentToPosition; // 1 for first position 2 for second position
    private Vector3 FirstPosition;
    private Vector3 SecondPosition;

    private void Start()
    {
        // Copy over the position of First and Second point
        FirstPosition = FirstPoint.position;
        SecondPosition = SecondPoint.position;
        CurrentToPosition = FirstPosition;

    }
    private void Update()
    {
        // Check if reach point. If yes then move to the next position
        if (transform.position == FirstPosition)
        {
            CurrentToPosition = SecondPosition;
        }
        else if (transform.position == SecondPosition)
        {
            CurrentToPosition = FirstPosition;
        }


        // Move enemy to the position
        transform.position = Vector3.MoveTowards(transform.position, CurrentToPosition, MoveSpeed * Time.deltaTime);

        // Flipping player image

        // Get where the enemy going to in terms of X axis
        Vector2 moveDirection = CurrentToPosition - transform.position;
        if (moveDirection.x < 0 && IsLookingRight) // Is player moving left but is looking right
        { 
            Flip();
        }
        else if (moveDirection.x > 0 && !IsLookingRight) // Is player moving right but not looking right
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        IsLookingRight = !IsLookingRight;

        // Flip the local scale rotation
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }

    public void OnKilled()
    {
        Destroy(gameObject, 0.1f);
    }
}
