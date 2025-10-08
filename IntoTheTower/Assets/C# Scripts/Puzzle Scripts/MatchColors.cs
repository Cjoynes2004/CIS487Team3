using UnityEngine;

public class MatchColors : MonoBehaviour
{
    public string color;
    ColorManager localManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localManager = GetComponentInParent<ColorManager>();
        if (localManager)
        {
            localManager.AddColor(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(color))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            localManager.RemoveColor(this);
        }
    }
}
