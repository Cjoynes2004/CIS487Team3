using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    private bool followPlayer;
    private Vector2 direction;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }

    public void FollowPlayer(Vector2 direction)
    {
        followPlayer = true;
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");


        if (isPlayer)
        {
            HealthPlayer damagePlayer = collision.gameObject.GetComponent<HealthPlayer>();
            damagePlayer.PlayerHurt(1);

            Destroy(gameObject);
        }
        else if (!collision.GetComponent<BossEnemy>() && !collision.GetComponent<LongRange>() && (collision.transform.parent && !collision.transform.parent.GetComponent<LongRange>()))
        {
            Destroy(gameObject);
        }
    }
}
