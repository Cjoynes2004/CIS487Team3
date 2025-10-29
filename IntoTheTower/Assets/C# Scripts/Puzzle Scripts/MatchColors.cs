using UnityEngine;

public class MatchColors : MonoBehaviour
{
    public string color; // Tag for the color, should be uppercase color, eg. "Yellow"
    ColorManager localManager; //This room's color puzzle manager
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Adds itself to the list of colors
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

    //On collision, if the colliding object has the tag, returns true and freezes object
    //Need to update so it only activiates when the entire object is in the color - TO DO
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
