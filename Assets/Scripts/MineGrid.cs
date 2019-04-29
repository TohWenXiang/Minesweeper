using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGrid : MonoBehaviour
{
    public Vector2Int size;
    public GameObject mineTilePrefab;
    [Range(0, 1)]
    public float mineProbability;

    private GameObject[,] mineGrid;

    private void Awake()
    {
        mineGrid = new GameObject[size.x, size.y];
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
        GameObject tile;
        
        tile = Instantiate(mineTilePrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        tile.name = tile.name.Substring(tile.name.Length - 7) + " (" + x + ", " + y + ")";

        mineGrid[x, y] = tile;
    }
}
