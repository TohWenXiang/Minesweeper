using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTile : MonoBehaviour
{
    public Sprite[] emptyMineSprites;
    public Sprite mineSprite;
    public Vector2Int index;
    public bool hasMine;

    private SpriteRenderer theSpriteRenderer;
    private MineGrid theMineGrid;

    private void Awake()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theMineGrid = transform.parent.GetComponent<MineGrid>();
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

    public void LoadSprite(int index)
    {
        theSpriteRenderer.sprite = emptyMineSprites[index];
    }

    public void OnMouseUp()
    {
        int numOfAdjacentRiggedTiles = theMineGrid.GetNumOfAdjacentRiggedTiles(index.x, index.y);

        if (hasMine == true)
        {
            //display all tiles
            theMineGrid.DisplayAllTiles();
            //display game over panel
        }
        else
        {
            if (numOfAdjacentRiggedTiles == 0)
            {
                //display all cells with zero adjacent rigged tiles
            }
            else
            {
                LoadSprite(numOfAdjacentRiggedTiles);
            }
        }
    }
}
