using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isHoldingjump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public LayerMask groundLayerMask;
    public LayerMask obstacleLayerMask;


    public float jumpForce = 5f; // The base force applied to the character when jumping
    public float holdForceMultiplier = 1.5f; // The multiplier applied to the jump force when the jump is held

    private bool canJump = true; // Indicates whether the character can currently jump
    private float currentJumpForce; // The actual jump force to be applied

    private void Update()
    {
        // Check for space key press or touch input
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (canJump)
            {
                currentJumpForce = jumpForce;
                Jump();
                isHoldingjump = true;
                holdJumpTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            if (canJump)
            {
                currentJumpForce = jumpForce * holdForceMultiplier;
                Jump();
                isHoldingjump = false;
            }
        }
    }

    private void Jump()
    {
        // Apply the jump force to the character
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        
        canJump = false; // Prevent jumping until the character lands again
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Not using collision detection in this script
        canJump = true; // Allow jumping again
    }
}
