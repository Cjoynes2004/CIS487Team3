using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    protected EnemyManager localManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        localManager = GetComponentInParent<EnemyManager>();
        if (localManager)
        {
            localManager.AddEnemy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public virtual void DamageEnemy(int dmgAmt)
    {
        localManager.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
