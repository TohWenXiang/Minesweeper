using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGrid : MonoBehaviour
{
    public Vector2Int size;
    public GameObject mineTilePrefab;
    [Range(0, 1)]
    public float mineProbability;

    private MineTile[,] mineGrid;

    private void Awake()
    {
        mineGrid = new MineTile[size.x, size.y];
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                CreateTile(x ,y);
            }
        }
    }

    void CreateTile(int x, int y)
    {
        MineTile tile;
        
        tile = Instantiate(mineTilePrefab, new Vector3(x, y, 0), Quaternion.identity, transform).GetComponent<MineTile>();
        tile.name = tile.name.Substring(0, tile.name.Length - 7) +  ((y * size.x) + x) + " (" + x + ", " + y + ")";

        tile.hasMine = Random.value < mineProbability;
        tile.index = new Vector2Int(x, y);

        mineGrid[x, y] = tile;
    }
    
    bool IsMineAtPosition(int x, int y)
    {
        //if within range
        if (x >= 0 && x < size.x && y >= 0 && y < size.y)
        {
            return mineGrid[x, y].hasMine;
        }
        else
        {
            return false;
        }
    }

    public int GetNumOfAdjacentRiggedTiles(int x, int y)
    {
        int results = 0;

        if (IsMineAtPosition(x - 1, y + 1) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x, y + 1) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x + 1, y + 1) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x - 1, y) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x + 1, y) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x - 1, y - 1) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x, y - 1) == true)
        {
            results++;
        }
        if (IsMineAtPosition(x + 1, y - 1) == true)
        {
            results++;
        }

        return results;
    }

    public void DisplayAllTiles()
    {
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                mineGrid[x, y].LoadSprite(GetNumOfAdjacentRiggedTiles(x, y));
            }
        }
    }
}
