using UnityEngine;

public class Grid
{
     private int width;
    private int height;
    private float cellSize;
    private PathNode[,] gridArray;
    private Vector3 originPosition;

    // write getters for width, height, cellSize
   
    public int Width
    {
        get { return width; }
    }
    
    public int Height
    {
        get { return height; }
    }

    public float CellSize
    {
        get { return cellSize; }
    }



    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new PathNode[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                gridArray[x, z] = new PathNode(true, x, z);
            }
        }
    }

    public PathNode GetPathNode(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            return null;
        }
    }

    public PathNode GetNodeFromWorldPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int z = Mathf.FloorToInt((worldPosition.z - originPosition.z) / cellSize);
        return GetPathNode(x, z);
    }

    public Vector3 GetWorldPositionFromNode(PathNode pathNode)
    {
        return new Vector3(pathNode.x * cellSize + originPosition.x, 0, pathNode.z * cellSize + originPosition.z);
    }
}

