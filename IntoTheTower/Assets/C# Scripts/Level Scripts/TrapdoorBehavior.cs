using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrapdoorBehavior : MonoBehaviour
{
    public List<bool> openFlags = new List<bool>();
    public LevelChange levelManager;
    public int numReqs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numReqs; ++i)
        {
            openFlags.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        MovePlayer player = collision.gameObject.GetComponent<MovePlayer>();
        if (player)
        {
            for (int i = 0; i < openFlags.Count; i++)
            {
                if (!openFlags[i])
                {
                    return;
                }
            }
            levelManager.GetNextLevel();
        }
    }
}
