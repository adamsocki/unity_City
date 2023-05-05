using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingCreationController : MonoBehaviour
{

    public Button addResidentialUnitButton;
    public Button removeResidentialUnitButton;
    public Button addCommercialUnitButton;
    public Button removeCommercialUnitButton;

    public Button initNewBuildingButton;
    public Button fabricateNewBuildingButton;

    public Text residentialUnitTotal;
    public Text commercialUnitTotal;

    private int residentialUnits;
    private int commercialUnits;


    // add listeners to all the buttons
    void Start()
    {
        addResidentialUnitButton.onClick.AddListener(AddResidentialUnit);
        removeResidentialUnitButton.onClick.AddListener(RemoveResidentialUnit);
        addCommercialUnitButton.onClick.AddListener(AddCommercialUnit);
        removeCommercialUnitButton.onClick.AddListener(RemoveCommercialUnit);

        initNewBuildingButton.onClick.AddListener(InitNewBuilding);
        fabricateNewBuildingButton.onClick.AddListener(FabricateNewBuilding);
        residentialUnits = 0;
        commercialUnits = 0;
    }

    private void AddResidentialUnit()
    {
        residentialUnits++;
        UpdateUnitTexts();
    }

    private void RemoveResidentialUnit()
    {
        if (residentialUnits > 0)
        {
            residentialUnits--;
            UpdateUnitTexts();
        }
    }

    private void AddCommercialUnit()
    {
        commercialUnits++;
        UpdateUnitTexts();
    }

    private void RemoveCommercialUnit()
    {
        if (commercialUnits > 0)
        {
            commercialUnits--;
            UpdateUnitTexts();
        }
    }

    private void UpdateUnitTexts()
    {
        residentialUnitTotal.text = "Residential Units: " + residentialUnits;
        commercialUnitTotal.text = "Commercial Units: " + commercialUnits;
    }

    private void InitNewBuilding()
    {
        // Your logic for initializing a new building goes here
    }

    private void FabricateNewBuilding()
    {
        // Your logic for fabricating a new building goes here
    }

}
