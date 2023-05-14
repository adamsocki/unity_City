using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridManager : MonoBehaviour
{



    private Grid<PathNode> grid;  
    public int width;  
    public int height;  
    public float cellSize = 1f;

    public void Start()
    {
        grid = new Grid<PathNode>(width, height, cellSize, Vector3.zero);

        for (int i = 0; i < 30; i ++)
        {
            grid.SetWalkable(i +10, i,  false);

        }
    }


    public void UpdateGrid()
    {

    }


    public void DetectObstacles()
    {

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
