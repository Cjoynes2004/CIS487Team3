using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    protected EnemyManager localManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Abstract: Adds itself to the room's enemy manager
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
    //Abstract collison class
    protected abstract void OnCollisionEnter2D(Collision2D collision);

    //Abstract damage class, removes enemy from scene
    public virtual void DamageEnemy(int dmgAmt)
    {
        localManager.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
