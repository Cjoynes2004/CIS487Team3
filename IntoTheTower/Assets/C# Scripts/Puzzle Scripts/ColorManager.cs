using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour //Eventually make an AbstractManager to derive all managers from
{
    public List<MatchColors> colors = new List<MatchColors>(); //List of colors that will be matched
    public TrapdoorBehavior trapdoor; //Trapdoor for this room
    public Sprite openTrapdoorSprite;

    private SpriteRenderer doorRender;
    private bool levelOver = false; // Returns true when room is over.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorRender = trapdoor.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colors.Count == 0 && !levelOver)
        {
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
            levelOver = true;
        }
    }

    //Adds color to list
    public void AddColor(MatchColors color)
    {
        colors.Add(color);
    }

    //Removes color from list
    public void RemoveColor(MatchColors color)
    {
        colors.Remove(color);
    }
}
