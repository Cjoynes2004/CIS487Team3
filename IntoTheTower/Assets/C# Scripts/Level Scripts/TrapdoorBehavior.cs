using UnityEngine;

public class TrapdoorBehavior : MonoBehaviour
{
    public bool isOpen;
    public LevelChange levelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        MovePlayer player = collision.gameObject.GetComponent<MovePlayer>();
        if (isOpen && player)
        {
            levelManager.GetNextLevel();
        }
    }
}
