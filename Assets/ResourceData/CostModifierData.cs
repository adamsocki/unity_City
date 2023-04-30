using UnityEngine;

[CreateAssetMenu(fileName = "CostModifierData", menuName = "Resource Modifier/Cost Modifier", order = 2)]
public class CostModifierData : ResourceModifierData
{
    public float constructionCost;
    public float maintenanceCost;
    public float maintenanceInterval;
    public ResourceType resourceType;



    // Add more properties related to costs, such as upgrade costs, etc.

    // Implement the ApplyModifier method to handle cost application
    public override void ApplyModifier(ResourceData resource, string costType)
    {
        switch (costType)
        {
            case "construction":
                resource.currentAmount -= constructionCost;
                break;
            case "maintenance":
                resource.currentAmount -= maintenanceCost;
                break;
            default:
                Debug.LogWarning($"Unknown cost type: {costType}");
                break;
        }
    }

   
}
