using UnityEngine;

[CreateAssetMenu(fileName = "TaxModifierData", menuName = "Resource Modifier/Tax Modifier", order = 3)]
public class TaxModifierData : ResourceModifierData
{
    public float taxRate; // A percentage value, e.g., 0.2 for 20%

    // Add more properties related to taxes, such as tax exemptions, etc.
    
    // Implement the ApplyModifier method to handle tax application
    public override void ApplyModifier(ResourceData resource, string modifierType)
    {
        // Apply tax to the resource, for example:
        resource.currentAmount -= Mathf.RoundToInt(resource.currentAmount * taxRate);
    }
}
