using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CloseRange : AbstractEnemy
{
    public float enemySpeed;
    public float enemyLaunchSpeed;
    public float launchInterval;
    public float launchDuration;
    public float launchTimeWindUp;
    public float launchTimeShake;
    public int randomMin;
    public int randomMax;

    public int enemyHealth;
    private Transform player;
    private float nextLaunch;
    private bool collided;
    private bool inLaunch = false;
    private Rigidbody2D rb;
    private Vector3 orginalPosition;
    private int randomStartTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Adds random start time to enemy launch, finds player for position
    protected override void Start()
    {
        base.Start();
        randomStartTime = Random.Range(randomMin, randomMax);
        nextLaunch = Time.time + randomStartTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        orginalPosition = transform.position;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        DamagePlayer player = collision.gameObject.GetComponent<DamagePlayer>();
        if (player != null)
        {
            player.PlayerHurt(1);
        }
        collided = true;
    }

    // Update is called once per frame, if in launch moves on, if not, sends to launch or follow

    void FixedUpdate()
    {
        if (player == null)
            return;

        if (!inLaunch)
        {
            FollowPlayer();

            if (Time.time >= nextLaunch)
            {
                StartCoroutine(LaunchAtPlayer());
                nextLaunch = Time.time + launchInterval;
            }
        }
    }

    //Handles enemy launch and windup
    private IEnumerator LaunchAtPlayer()
    {
        inLaunch = true;

        Vector2 startPos = transform.position;
        float shakeEnd = Time.time + launchTimeWindUp;

        while (Time.time < shakeEnd)
        {
             Vector3 shakeOffSet = new Vector2(Random.Range(-0.1f, 0.1f),
             Random.Range(-0.1f, 0.1f));
             rb.MovePosition(startPos + (Vector2)shakeOffSet);
             yield return null;
        }

        rb.MovePosition(startPos);

        Vector2 direction = (player.position - transform.position).normalized;
        float startTime = Time.time;

        while (Time.time < startTime + launchDuration)
        {
            if (collided) {
                collided = false;
                break;
                
            }
            rb.MovePosition(rb.position + direction * enemyLaunchSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        inLaunch = false;
    }

    //Simple following of player, Linear movement
    private void FollowPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * enemySpeed * Time.deltaTime);
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
