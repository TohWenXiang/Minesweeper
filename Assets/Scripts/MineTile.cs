using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTile : MonoBehaviour
{
    public Sprite[] emptyMineSprites;
    public Sprite mineSprite;

    private SpriteRenderer theSpriteRenderer;
    private bool hasMine;

    private void Awake()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //LoadSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSprite(int index)
    {
        if (hasMine)
        {
            theSpriteRenderer.sprite = mineSprite;
        }
    }
}
