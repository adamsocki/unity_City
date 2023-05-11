using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialManager : MonoBehaviour
{
   
    public ResidentManager residentManager;


    // // singleton instance
    // public static CommercialManager instance;

    // // set singleton instance
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    // }

    // list of all commercial units
    public List<CommercialUnit> commercialUnits = new List<CommercialUnit>();

    // list of all commercial units that are open
    public List<CommercialUnit> openUnits = new List<CommercialUnit>();

    // list of all commercial units that are closed
    public List<CommercialUnit> closedUnits = new List<CommercialUnit>();

    // list of all commercial units that are occupied
    public List<CommercialUnit> occupiedUnits = new List<CommercialUnit>();

    // list of all commercial units that are unoccupied
    public List<CommercialUnit> unoccupiedUnits = new List<CommercialUnit>();

    // list of all commercial units that are for sale
    public List<CommercialUnit> forSaleUnits = new List<CommercialUnit>();

    // list of all commercial units that are not for sale
    public List<CommercialUnit> notForSaleUnits = new List<CommercialUnit>();

    // list of all commercial units that are for rent
    public List<CommercialUnit> forRentUnits = new List<CommercialUnit>();

    // list of all commercial units that are not for rent
    public List<CommercialUnit> notForRentUnits = new List<CommercialUnit>();




    // assign commercial unit to resident
    public void AssignUnitAndResident(CommercialUnit unit, ResidentData resident)
    {
        unit.resident = resident;
        unit.isOccupied = true;
        resident.unitAssignedWork = unit;
    }

    // unassign commercial unit from resident
    public void UnassignUnit(CommercialUnit unit)
    {
        unit.resident = null;
        unit.isOccupied = false;
    }

    // unassign resident from commercial unit
    public void UnassignResident(ResidentData resident)
    {
        resident.unitAssignedWork = null;
    }

    // open commercial unit
    public void OpenUnit(CommercialUnit unit)
    {
        unit.isOpen = true;
    }

    // test to assign resident to commercial unit
    public void TestAssignResident(CommercialUnit unit, ResidentData resident)
    {
        if (unit.isOpen && !unit.isOccupied)
        {
            AssignUnitAndResident(unit, resident);
        }
    }

    // get list of all commercial units from BuildingManager
    public void GetCommercialUnits()
    {
       // commercialUnits = BuildingManager.unitTypeMap[UnitType.Commercial];
    }
    
}
