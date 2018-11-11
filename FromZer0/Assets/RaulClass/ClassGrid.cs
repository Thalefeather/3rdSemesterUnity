using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class vectorExtension
{
    public static Vector2 xy(this Vector3 target)
    {
        return new Vector2(target.x, target.y);
    }
}

public class ClassGrid : MonoBehaviour
{

    public ClassNode[,] grid;
    public Vector2 worldSize;
    public float nodeRadius;

    public void Init()
    {
        if (grid != null)
            return;

        nodeDiamater = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(worldSize.x / nodeDiamater);
        gridSizeY = Mathf.RoundToInt(worldSize.y / nodeDiamater);
        CreateGrid();
    }

    public LayerMask unwalkableMask;

    float nodeDiamater;
    int gridSizeX, gridSizeY;

    public int Count => gridSizeX * gridSizeY;

    public Vector2 Origin { get { return transform.position.xy() - Vector2.right * worldSize.x / 2 - Vector2.up * worldSize.y / 2; } }


    // Use this for initialization
    void Awake()
    {
        Init();
    }

    private void CreateGrid()
    {
        grid = new ClassNode[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //create the nodes
                Vector2 worldPoint = GridToWorldPoint(x, y);
                bool isWalkable = (Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask) == null);
                grid[x, y] = new ClassNode(isWalkable, worldPoint, x, y);
            }
        }
    }

    private Vector2 GridToWorldPoint(int x, int y)
    {
        float offsetX = x * nodeDiamater + nodeRadius;
        float offsetY = y * nodeDiamater + nodeRadius;

        return Origin + Vector2.right * offsetX + Vector2.up * offsetY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, worldSize);

        if (grid == null) return;
        foreach (var n in grid)
        {
            Gizmos.color = (n.walkable) ? Color.white : Color.red;
            Gizmos.DrawWireCube(n.worldPosition, Vector3.one * (nodeDiamater - 0.1f));
        }
    }
}
