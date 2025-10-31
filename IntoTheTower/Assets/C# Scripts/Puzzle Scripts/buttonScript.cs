using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public TrapdoorBehavior trapdoor;
    public Sprite openTrapdoorSprite;
    public GameObject resetBox;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer doorRender;
    private float initX;
    private float initY;
    private Quaternion initRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initX = resetBox.transform.position.x;
        initY = resetBox.transform.position.y;
        doorRender = trapdoor.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingBoxCollision box = collision.gameObject.GetComponent<movingBoxCollision>();
        MovePlayer player = collision.gameObject.GetComponent<MovePlayer>();

        if (box)
        {
            spriteRenderer.color = Color.green;
            for (int i = 0; i < trapdoor.openFlags.Count; i++)
            {
                if (!trapdoor.openFlags[i])
                {
                    trapdoor.openFlags[i] = true;
                    if (i == trapdoor.openFlags.Count - 1)
                    {
                        doorRender.sprite = openTrapdoorSprite;
                    }
                    break;
                }
            }
        }
        else if (player)
        {
            resetBox.transform.SetPositionAndRotation(new Vector3(initX, initY, 0), initRotation);
        }
    }
}
