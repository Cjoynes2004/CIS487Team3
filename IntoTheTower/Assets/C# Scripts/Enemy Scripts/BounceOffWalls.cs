using UnityEngine;

public class BounceOffWalls : AbstractEnemy
{
    public float enemySpeed;

    private Vector3 moveDirection;
    private float enemX;
    private float enemY;
    private int enemyHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        enemX = Random.value;
        enemY = Random.value;
        moveDirection = new Vector3 (enemX, enemY, 0f);
        enemyHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Normalize();
        transform.Translate(moveDirection * enemySpeed * Time.deltaTime, Space.World);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        DamagePlayer player = collision.gameObject.GetComponent<DamagePlayer>();
        if (player != null)
        {
            player.PlayerHurt(1);
        }
        moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
    }

    public override void DamageEnemy(int dmgAmt)
    {
        enemyHealth -= dmgAmt;
        enemySpeed *= 2;
        transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);

        if (enemyHealth <= 0)
        {
            base.DamageEnemy(dmgAmt);
        }
    }
}
