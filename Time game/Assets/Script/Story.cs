using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{

    public int activeSprite;
    public Sprite[] storyCollection;

    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        activeSprite = Mathf.Clamp(activeSprite, 0, storyCollection.Length);
    }

    public void PrevStory()
    {
        if(activeSprite > 0)
        {
            activeSprite--;
        }
        else
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.Story();
        }

        rend.sprite = storyCollection[activeSprite];

        
    }

    public void NextStory()
    {
        activeSprite++;
        if (activeSprite >= storyCollection.Length)
        {
            activeSprite = 0;
        }
        
        rend.sprite = storyCollection[activeSprite];
    }
}
