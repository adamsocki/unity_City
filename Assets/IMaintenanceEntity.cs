public interface IMaintenanceEntity
{
    CostModifierData GetMaintenanceCostData(); // Get the maintenance cost data associated with the entity
    void ApplyMaintenanceCost(ResourceManager resourceManager); // Add ResourceManager parameter
    bool HasMaintenanceCosts(); // Check if the entity has maintenance costs
}
