﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class Grid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 worldSize;
    public float nodeRadius;

    public Node[,] grid;
    float nodeDiameter;
    int gridSizeX, gridSizeY;

    public int Count => gridSizeX * gridSizeY;
    public Vector2 Origin => transform.position.xy() - Vector2.right * worldSize.x / 2 - Vector2.up * worldSize.y / 2;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (grid != null)
            return;

        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(worldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(worldSize.y / nodeDiameter);
        CreateGrid();
    }

    public void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = GetWorldPoint(x, y);
                bool isWalkable = (Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask.value) == null);
                grid[x, y] = new Node(isWalkable, worldPoint, x, y);
            }
        }
    }

    public Vector2 GetWorldPoint(int x, int y)
    {
        float offsetX = x * nodeDiameter + nodeRadius;
        float offsetY = y * nodeDiameter + nodeRadius;
        return Origin + Vector2.right * offsetX + Vector2.up * offsetY;
    }

    public List<Node> GetNeighbours(Node node, int depth = 1)
    {
        List<Node> neighbours = new List<Node>();

         for (int x = -depth; x <= depth; x++)
         {
             for (int y = -depth; y <= depth; y++)
             {
                 if (x == 0 && y == 0) continue;
                 int checkX = node.gridX + x;
                 int checkY = node.gridY + y;

                 if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                     neighbours.Add(grid[checkX, checkY]);
             }
         }

         return neighbours;

        /*int x = 0, y = 0;
        y = 0;
        y = 0;
        for (x = -1; x <= 1; ++x)
        {
            var neighbor = AddNodeNeighbour(x, y, node);
            if (neighbor != null)
                yield return neighbor;
        }

        x = 0;
        for (y = -1; y <= 1; ++y)
        {
            var neighbor = AddNodeNeighbour(x, y, node);
            if (neighbor != null)
                yield return neighbor;
        }
        yield return neighbours;*/
    }

    Node AddNodeNeighbour(int x, int y, Node node)
    {
        if (x == 0 && y == 0)
        {
            return null;
        }

        int checkX = node.gridX + x;
        int checkY = node.gridY + y;

        if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
        {
            return grid[checkX, checkY];
        }

        return null;
    }

    public Node NodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = Mathf.Clamp01((worldPosition.x + worldSize.x / 2) / worldSize.x);
        float percentY = Mathf.Clamp01((worldPosition.y + worldSize.y / 2) / worldSize.y);
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public Node ClosestWalkableNode(Node node)
    {
        int maxRadius = Mathf.Max(gridSizeX, gridSizeY) / 2;
        for (int i = 1; i < maxRadius; i++)
        {
            Node n = FindWalkableInRadius(node.gridX, node.gridY, i);
            if (n != null)
                return n;
        }
        return null;
    }

    Node FindWalkableInRadius(int x, int y, int radius)
    {
        for (int i = -radius; i <= radius; i++)
        {
            int vx = i + x;
            int hy = i + y;

            // top, right, bottom, left
            if (IsWalkable(vx, y + radius)) return grid[vx, y + radius];
            if (IsWalkable(x + radius, hy)) return grid[x + radius, hy];
            if (IsWalkable(vx, y - radius)) return grid[vx, y - radius];
            if (IsWalkable(x - radius, hy)) return grid[x - radius, hy];
        }

        return null;
    }

    bool InBounds(int x, int y)
    {
        return (x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY);
    }

    bool IsWalkable(int x, int y)
    {
        return InBounds(x, y) && grid[x, y].walkable;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, worldSize);

        if (grid == null) return;
        foreach (Node n in grid)
        {
            Gizmos.color = (n.walkable) ? Color.white : Color.red;
            Gizmos.DrawWireCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
        }
    }
}