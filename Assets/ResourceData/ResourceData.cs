using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Resource Data", order = 5)]
public class ResourceData : ScriptableObject
{
    public ResourceType resourceType;
    public float startingAmount;
    public float currentAmount;

    // Add more properties related to the resource, such as income rate, etc.
}
