using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<ResourceData> resources;
    // [SerializeField] private List<ResourceModifierData> modifiers;
    public List<IMaintenanceEntity> maintenanceEntities = new List<IMaintenanceEntity>();
    public Dictionary<ResourceType, float> MaintenanceCosts { get; private set; } = new Dictionary<ResourceType, float>();



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

    public float GetMaintenanceCostForResourceType(ResourceType resourceType)
    {
        float cost;
        if (MaintenanceCosts.TryGetValue(resourceType, out cost))
        {
            return cost;
        }
        else
        {
           // Debug.LogWarning($"No maintenance cost found for resource type: {resourceType}");
            return 0f;
        }
    }


    public void ApplyModifier(ResourceModifierData modifier, ResourceType resourceType, string modifierType)
    {
        ResourceData targetResource = GetResourceByType(resourceType);
        Debug.Log(targetResource);
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

    public void AddToMaintenanceCosts(ResourceType resourceType, float cost)
    {
        if (MaintenanceCosts.ContainsKey(resourceType))
        {
            MaintenanceCosts[resourceType] += cost;
        }
        else
        {
            MaintenanceCosts[resourceType] = cost;
        }
        Debug.Log(MaintenanceCosts[ResourceType.Cash]);
    }

    public void ApplyMaintenanceCosts()
    {
        // Iterate through all maintenance entitiesU    

        Debug.Log("ApplyMaintenanceCosts()");

        //foreach (IMaintenanceEntity maintenanceEntity in maintenanceEntities)
        //{
        //    // Call the ApplyMaintenanceCost method on each entity and pass the ResourceManager instance
        //    maintenanceEntity.ApplyMaintenanceCost(this);
        //}

        foreach (ResourceType resourceType in MaintenanceCosts.Keys)
        {
            float maintenanceCost = MaintenanceCosts[resourceType];
            ResourceData resourceData = GetResourceByType(resourceType);

            if (resourceData != null)
            {
                resourceData.currentAmount -= maintenanceCost;
            }
            else
            {
                Debug.LogWarning($"Resource data not found for resource type: {resourceType}");
            }
        }

    }






}
