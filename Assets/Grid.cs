using UnityEngine;




public class Grid<T> where T : PathNode, new()
{
    private int width;
    private int height;
    private float cellSize;
    private T[,] gridArray;
    private Vector3 originPosition;
   


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

        gridArray = new T[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                gridArray[x, z] = new T();
            }
        }
    }

    public T GetGridObject(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            return default(T);
        }
    }
    public T GetGridObjectFromWorldPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int z = Mathf.FloorToInt((worldPosition.z - originPosition.z) / cellSize);
        return GetGridObject(x, z);
    }


    // set the node to be walkable or not
    public void SetWalkable(int x, int z, bool isWalkable)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z].isWalkable = isWalkable;
        }
    }

    public void DetectBuilding()
    {

    }

    public T GetPathNode(int x, int z)
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

    public T GetNodeFromWorldPosition(Vector3 worldPosition)
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

