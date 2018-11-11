using UnityEngine;
using System.Collections;

public class ClassNode
{
    public bool walkable;
    public Vector2 worldPosition;
    public int gridX, gridY;

    public ClassNode(bool walkable, Vector2 worldPosition, int gridX, int gridY)
    {
        this.walkable = walkable;
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
    }
}