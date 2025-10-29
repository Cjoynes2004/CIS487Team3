using JetBrains.Annotations;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float playerSpeed; // Speed of the player
    public bool canMove = true; // Determines whether player can move or shoot
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //Takes in Player inputs via wasd or arrow keys and moves the player accordingly.
    private void PlayerMove()
    {
        if (canMove)
        {
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");

            if (hInput != 0 || vInput != 0)
            {
                Vector3 moveDirection;
                moveDirection = new Vector3(hInput, vInput, 0f);
                moveDirection.Normalize();
                transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movingBoxCollision box = collision.gameObject.GetComponent<movingBoxCollision>();
        if (box != null)
        {
            // Determine push direction based on player to box
            Vector2 pushDir = (box.transform.position - transform.position).normalized;
            box.Push(pushDir);
        }
    }
}
