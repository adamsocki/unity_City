using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    public UnitData unitData;

    public void InitializeUnitController(UnitData unitData)
    {
        this.unitData = unitData;
    }
}
