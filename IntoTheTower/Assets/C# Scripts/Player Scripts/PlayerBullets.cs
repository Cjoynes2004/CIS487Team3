using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AbstractEnemy enemy = collision.gameObject.GetComponent<AbstractEnemy>();
        if (enemy)
        {
            enemy.DamageEnemy(1);
        }
        Destroy(gameObject);
    }
}
