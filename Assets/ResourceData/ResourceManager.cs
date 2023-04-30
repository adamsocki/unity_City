using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<ResourceData> resources;
    // [SerializeField] private List<ResourceModifierData> modifiers;
    public List<IMaintenanceEntity> maintenanceEntities = new List<IMaintenanceEntity>();



    // Initialize the ResourceManager
    public void InitResourceManager()
    {
        // Add any initialization code here, if needed
        ResourceData cashResourceData = GetResourceByType(ResourceType.Cash);
        cashResourceData.currentAmount = cashResourceData.startingAmount;
    }

    // Update the ResourceManager
    public void UpdateResourceManager()
    {
        // Add any update code here, if needed
    }

    public ResourceData GetResourceByType(ResourceType resourceType)
    {
        foreach (ResourceData resource in resources)
        {
            if (resource.resourceType == resourceType)
            {
                return resource;
            }
        }

        Debug.LogWarning($"Resource '{resourceType}' not found.");
        return null;
    }

    public void ApplyModifier(ResourceModifierData modifier, ResourceType resourceType, string modifierType)
    {
        ResourceData targetResource = GetResourceByType(resourceType);
        modifier.ApplyModifier(targetResource, modifierType);
    }

    

    private void OnEnable()
    {
        TimeEventManager.OnDayPassed += ApplyMaintenanceCosts;

    }

    private void OnDisable()
    {
        TimeEventManager.OnDayPassed -= ApplyMaintenanceCosts;
    }

    private void UpdateMaintenanceCosts(CostModifierData costModifier)
    {
        // get all buildings

        // get all residents
       

        //foreach (ICostModifierApplicable entity in entitiesWithMaintenanceCost)
        //{
        //    entity.ApplyCostModifier("maintenance");
        //}
    }

    public void ApplyMaintenanceCosts()
    {
        // Iterate through all maintenance entitiesU    

        

        foreach (IMaintenanceEntity maintenanceEntity in maintenanceEntities)
        {
            Debug.Log("Inovke");
            // Call the ApplyMaintenanceCost method on each entity and pass the ResourceManager instance
            maintenanceEntity.ApplyMaintenanceCost(this);
        }
    }






}
