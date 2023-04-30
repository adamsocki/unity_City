using UnityEngine;

public abstract class ResourceModifierData : ScriptableObject
{
    public string modifierName;

    // Add more properties related to the base modifier, if needed

    // Add an abstract method that will be implemented by subclasses to modify the resource
    public abstract void ApplyModifier(ResourceData resource, string modifierType);

    
}
