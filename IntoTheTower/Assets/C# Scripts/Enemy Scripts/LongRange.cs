using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class LongRange : AbstractEnemy
{
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private int timeDelay, min, max;
    [SerializeField]
    private GameObject bullet;

    private Rigidbody2D rb;
    private bool followPlayer;
    private Transform player;
    private int enemyHealth = 3;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");

        if (isPlayer)
        {
            followPlayer = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");

        if (isPlayer)
        {
            followPlayer = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        timeDelay = Random.Range (min, max);
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        followPlayer = true;
        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        while (true) {
            GameObject newBullet = Instantiate(bullet);
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            Vector2 direction = (player.position - transform.position).normalized;

            newBullet.transform.position = transform.position;

            // Rotate bullet to face direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            bulletRb.rotation = angle;

            newBullet.GetComponent<EnemyBullet>().FollowPlayer(direction);

            yield return new WaitForSeconds(timeDelay);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction  * enemySpeed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public override void DamageEnemy(int dmgAmt)
    {
        enemyHealth -= dmgAmt;
        if (enemyHealth <= 0)
        {
            base.DamageEnemy(dmgAmt);
        }
    }
}
