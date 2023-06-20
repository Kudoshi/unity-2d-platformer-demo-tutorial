using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Transform FirstPoint;
    public Transform SecondPoint;
    public bool ShouldFlip;
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

        if (ShouldFlip)
        {
            if (moveDirection.x < 0 && IsLookingRight) // Is player moving left but is looking right
            {
                Flip();
            }
            else if (moveDirection.x > 0 && !IsLookingRight) // Is player moving right but not looking right
            {
                Flip();
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = null;
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
