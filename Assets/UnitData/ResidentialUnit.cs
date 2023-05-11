using UnityEngine;

[CreateAssetMenu(fileName = "ResidentialUnit", menuName = "Unit Data/Residential", order = 1)]
public class ResidentialUnit : UnitData
{
    // Add residential unit-specific properties and methods here
    
    public bool isOccupied { get; set; } // Add this line
    
    // add resident assigned to home
    public ResidentData resident { get; set; }
    



    public ResidentialUnit()
    {
        isOccupied = false;
    }
}
