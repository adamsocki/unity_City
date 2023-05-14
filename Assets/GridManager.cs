using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Grid grid;  
    public int width = 10;  
    public int height = 10;  
    public float cellSize = 1f;

    public void Start()
    {
        grid = new Grid(width, height, cellSize, Vector3.zero);
    }

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int z = 0; z < grid.Height; z++)
                {
                    PathNode pathNode = grid.GetPathNode(x, z);

                    // Choose the color of the gizmo based on the walkability of the node
                    Gizmos.color = pathNode.isWalkable ? Color.white : Color.red;

                    // Draw a small cube at the position of the node
                    Vector3 pathNodePos = grid.GetWorldPositionFromNode(pathNode);
                    Gizmos.DrawCube(pathNodePos, Vector3.one * (grid.CellSize - 0.1f)); // Subtract a small amount to create a grid effect
                }
            }
        }
    }

}
