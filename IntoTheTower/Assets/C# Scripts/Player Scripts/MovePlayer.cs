using JetBrains.Annotations;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float playerSpeed; // Speed of the player
    public bool canMove = true; // Determines whether player can move or shoot


    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
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
                animator.SetBool("isWalking", true);
                if (hInput > 0 && vInput == 0)
                {
                    animator.SetInteger("faceDirection", 3);
                }
                else if (hInput < 0 && vInput == 0)
                {
                    animator.SetInteger("faceDirection", 7);
                }
                else if (hInput == 0 && vInput < 0)
                {
                    animator.SetInteger("faceDirection", 1);
                }
                else if (hInput == 0 && vInput > 0)
                {
                    animator.SetInteger("faceDirection", 5);
                }
                else if (hInput < 0 && vInput > 0)
                {
                    animator.SetInteger("faceDirection", 6);
                }
                else if (hInput > 0 && vInput < 0)
                {
                    animator.SetInteger("faceDirection", 2);
                }
                else if (hInput < 0 && vInput < 0)
                {
                    animator.SetInteger("faceDirection", 8);
                }
                else if (hInput > 0 && vInput > 0)
                {
                    animator.SetInteger("faceDirection", 4);
                }
                    Vector3 moveDirection;
                moveDirection = new Vector3(hInput, vInput, 0f);
                moveDirection.Normalize();
                transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetInteger("faceDirection", 0);
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
