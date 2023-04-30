using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Resource Data", order = 5)]
public class ResourceData : ScriptableObject
{
    public ResourceType resourceType;
    public int startingAmount;
    public int currentAmount;

    // Add more properties related to the resource, such as income rate, etc.
}
