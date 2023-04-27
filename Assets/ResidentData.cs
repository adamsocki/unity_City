using UnityEngine;

[CreateAssetMenu(fileName = "ResidentData", menuName = "Resident Data", order = 2)]
public class ResidentData : ScriptableObject
{
    public string residentName;
    public int age;
    public Building home;

    // Add other resident-specific attributes and methods here
}
