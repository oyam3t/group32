using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jump;

    private float move;

    public Rigidbody2D rb;
    public bool isJumping;
    public bool isMoving; // Declare the isMoving variable

    // Reference to the Animator component
    private Animator animator;

    // Reference to the character's Transform component for flipping
    private Transform characterTransform;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Get the Transform component attached to the GameObject
        characterTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // Update isMoving based on whether there is horizontal movement
        isMoving = Mathf.Abs(move) > 0.01f;

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        // Update animator parameters
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);

        // Flip character based on movement direction
        if (move > 0)
        {
            characterTransform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            characterTransform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }
}
