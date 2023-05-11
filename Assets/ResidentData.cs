using UnityEngine;

[CreateAssetMenu(fileName = "ResidentData", menuName = "Resident Data", order = 2)]
public class ResidentData : ScriptableObject
{
    public string residentName;
    public int age;
    public bool hasHome;
    public Building home;
    public Building portOfEntry;
    public ResidentialUnit unitAssignedHome;

    public Building work;
    public UnitData unitAssignedWork;
    public bool isEmployed;

    // current locations
    public Building currentBuilding;
    public CommercialUnit currentLocationCommercialUnit;
    public ResidentialUnit currentLocationResidentialUnit;

    public bool isAtDestination;
    // is home
    public bool isHome;
    // is at work
    public bool isAtWork;
    // is at port of entry
    public bool isAtPortOfEntry;
    // is at commercial unit
    public bool isAtCommercialUnit;
    // is at residential unit
    public bool isAtResidentialUnit;

    // is moving
    public bool isMoving;

    // is in transit
    public bool isInTransit;

    // destination
    public Building destinationBuilding;
    public CommercialUnit destinationCommercialUnit;
    public ResidentialUnit destinationResidentialUnit;

    


    // Add other resident-specific attributes and methods here
}
