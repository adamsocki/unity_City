using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<ResourceData> resources;
   // [SerializeField] private List<ResourceModifierData> modifiers;


    // Initialize the ResourceManager
    public void InitResourceManager()
    {
        // Add any initialization code here, if needed
        ResourceData cashResourceData = GetResourceByName(ResourceType.Cash);
        cashResourceData.currentAmount = cashResourceData.startingAmount;
    }

    // Update the ResourceManager
    public void UpdateResourceManager()
    {
        // Add any update code here, if needed
    }

    public ResourceData GetResourceByName(ResourceType resourceType)
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
        ResourceData targetResource = GetResourceByName(resourceType);
        modifier.ApplyModifier(targetResource, modifierType);
    }

}
