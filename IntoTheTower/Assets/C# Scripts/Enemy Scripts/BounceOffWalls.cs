using UnityEngine;

public class BounceOffWalls : MonoBehaviour
{
    public float enemySpeed;

    private Vector3 moveDirection;
    private float enemX;
    private float enemY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemX = Random.value;
        enemY = Random.value;
        moveDirection = new Vector3 (enemX, enemY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Normalize();
        transform.Translate(moveDirection * enemySpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        MovePlayer player = col.gameObject.GetComponent<MovePlayer>();
        /*float posX = transform.position.x;
        float posY = transform.position.y;
        float colX = col.transform.position.x;
        float colY = col.transform.position.y;*/

        if (player != null)
        {
            //Behavior to damage player
        }
        moveDirection = Vector3.Reflect(moveDirection, col.contacts[0].normal);
    }
}
