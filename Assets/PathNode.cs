
public class PathNode
{
    public bool isWalkable;
    public int x;
    public int z;

    public PathNode previousNode;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode() { } // This is the parameterless constructor

    public PathNode(bool isWalkable, int x, int z)
    {
        this.isWalkable = isWalkable;
        this.x = x;
        this.z = z;
    }


  

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
