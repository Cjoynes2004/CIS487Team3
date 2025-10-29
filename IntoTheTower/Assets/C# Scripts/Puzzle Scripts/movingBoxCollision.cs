using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class movingBoxCollision : MonoBehaviour
{
    public float slideSpeed = 5f;
    public float stopDistance = 0.05f; // small buffer to stop before overlap

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isSliding = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if (isSliding)
        {
            rb.linearVelocity = moveDirection * slideSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If hitting wall or obstacle, stop sliding
        if (!collision.gameObject.CompareTag("Player"))
        {
            isSliding = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void Push(Vector2 pushDirection)
    {
        if (!isSliding)
        {
            // Only allow pure 4-direction movement
            if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.y))
                moveDirection = new Vector2(Mathf.Sign(pushDirection.x), 0);
            else
                moveDirection = new Vector2(0, Mathf.Sign(pushDirection.y));

            // Check if blocked immediately (raycast in front)
            if (!IsPathClear(moveDirection))
            {
                isSliding = false;
                rb.linearVelocity = Vector2.zero;
                return;
            }

            isSliding = true;
        }
    }

    private bool IsPathClear(Vector2 dir)
    {
        // Simple raycast check
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, LayerMask.GetMask("Obstacles"));
        return hit.collider == null;
    }
}