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

    public Text buildingName;
    public Button generateBuildingName;
    public BuildingNameGenerator buildingNameGenerator;

    private int residentialUnits;
    private int commercialUnits;

    public UIController uiController;
    public GameObject residentialBuildingPrefab;
    public GameObject portOfEntryBuildingPrefab;

    public ResidentialUnit residentialUnitDataTemplate;
    public CommercialUnit commercialUnitDataTemplate;

    public BuildingType buildingType;

    public CostModifierData costData;



    // add listeners to all the buttons
    public void InitBuildingCreationController()
    {
        if (buildingType == BuildingType.Residential1)
        {
            addResidentialUnitButton.onClick.AddListener(AddResidentialUnit);
            removeResidentialUnitButton.onClick.AddListener(RemoveResidentialUnit);
            addCommercialUnitButton.onClick.AddListener(AddCommercialUnit);
            removeCommercialUnitButton.onClick.AddListener(RemoveCommercialUnit);

            UpdateUnitTexts();
        }
        generateBuildingName.onClick.AddListener(GenerateBuildingName);

        initNewBuildingButton.onClick.AddListener(InitNewBuilding);
        fabricateNewBuildingButton.onClick.AddListener(FabricateNewBuilding);

    }

    private void GenerateBuildingName()
    {
        buildingName.text = buildingNameGenerator.GenerateRandomName(buildingType);
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
        if (buildingType == BuildingType.Residential1)
        {
        residentialUnitTotal.text = "Residential Units: " + residentialUnits;
        commercialUnitTotal.text = "Commercial Units: " + commercialUnits;

        }
    }

    private void InitNewBuilding()
    {
        
        residentialUnits = 0;
        commercialUnits = 0;
        UpdateUnitTexts();

    }

    private void FabricateNewBuilding()
    {
   
        CostModifierData newInitialCost = ScriptableObject.CreateInstance<CostModifierData>();

        switch (buildingType)
        {
            case BuildingType.PortOfEntry:

                BuildingData portOfEntryBuildingData = ScriptableObject.CreateInstance<BuildingData>();

                portOfEntryBuildingData.buildingName = buildingName.text;
                portOfEntryBuildingData.CostModifierData = newInitialCost;
                
                portOfEntryBuildingData.ModifyInitialCost(40);
                uiController.SetPlaceableObject(portOfEntryBuildingPrefab, EntityFactory.EntityType.Building, buildingType, portOfEntryBuildingData);
                break;

            case BuildingType.Residential1:
                BuildingData residential1BuildingData = ScriptableObject.CreateInstance<BuildingData>();

                for (int i = 0; i < residentialUnits; i++)
                {
                    ResidentialUnit newResidentialUnit = Instantiate(residentialUnitDataTemplate);
                    residential1BuildingData.units.Add(newResidentialUnit);
                   
                } 
                for (int i = 0; i < commercialUnits; i++)
                {
                    CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
                    residential1BuildingData.units.Add(newCommercialUnit);
                }
                residential1BuildingData.buildingName = buildingName.text; 
                residential1BuildingData.CostModifierData = newInitialCost;
                residential1BuildingData.ModifyInitialCost((residentialUnits * 10) + (commercialUnits * 20));
                uiController.SetPlaceableObject(residentialBuildingPrefab, EntityFactory.EntityType.Building, buildingType, residential1BuildingData);
                residentialUnits = 0;
                commercialUnits = 0;

                break;

            default:

                break;
        }

       
        buildingName.text = "No Name";
        UpdateUnitTexts();
    }

}
