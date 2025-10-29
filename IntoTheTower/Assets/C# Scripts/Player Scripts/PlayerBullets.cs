using System;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    public int chainShotLength;
    public TrapdoorBehavior reflectTrapdoor;

    private bool[] chainShot;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool bounceRegistered = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chainShot = new bool[chainShotLength];
        sprite = GetComponent<SpriteRenderer>();
    }
    //Damages enemy on collisin and erases bullet regardless
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounceRegistered) return;
        bounceRegistered = true;
        Invoke(nameof(ResetBounce), 0.05f); // short cooldown before next bounce counts

        AbstractEnemy enemy = collision.gameObject.GetComponent<AbstractEnemy>();
        ReflectSurface bounce = collision.gameObject.GetComponent<ReflectSurface>();

        if (enemy)
        {
            enemy.DamageEnemy(1);
            Destroy(gameObject);
            Destroy(this);
        }
        else if (bounce)
        {
            sprite.color = Color.green;
            rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, collision.contacts[0].normal);
            for (int i = 0; i <= chainShot.Length; ++i)
            {
                if (!chainShot[i])
                {
                    chainShot[i] = true;
                    if (i == chainShot.Length - 1)
                    {
                        for (int y = 0; y < reflectTrapdoor.openFlags.Count; y++)
                        {
                            if (!reflectTrapdoor.openFlags[y])
                            {
                                reflectTrapdoor.openFlags[y] = true;
                                break;
                            }
                        }
                    }
                    break;
                }               
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    private void ResetBounce()
    {
        bounceRegistered = false;
    }
}
