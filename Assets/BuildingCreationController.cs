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

    public ResidentialUnit residentialUnitDataTemplate;
    public CommercialUnit commercialUnitDataTemplate;


    // add listeners to all the buttons
    void Start()
    {
        addResidentialUnitButton.onClick.AddListener(AddResidentialUnit);
        removeResidentialUnitButton.onClick.AddListener(RemoveResidentialUnit);
        addCommercialUnitButton.onClick.AddListener(AddCommercialUnit);
        removeCommercialUnitButton.onClick.AddListener(RemoveCommercialUnit);
        generateBuildingName.onClick.AddListener(GenerateBuildingName);

        initNewBuildingButton.onClick.AddListener(InitNewBuilding);
        fabricateNewBuildingButton.onClick.AddListener(FabricateNewBuilding);

        //residentialUnits = 0;
        // commercialUnits = 0;
        UpdateUnitTexts();
    }

    private void GenerateBuildingName()
    {
        //Debug.Log(buildingNameGenerator.GenerateRandomName());
        buildingName.text = buildingNameGenerator.GenerateRandomName();
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
        residentialUnits = 0;
        commercialUnits = 0;
        UpdateUnitTexts();

    }

    private void FabricateNewBuilding()
    {
        // Your logic for fabricating a new building goes here
        BuildingData buildingData = ScriptableObject.CreateInstance<BuildingData>();
        buildingData.buildingName = buildingName.text;
        for (int i  = 0; i < residentialUnits; i++)
        {
            ResidentialUnit newResidentialUnit = Instantiate(residentialUnitDataTemplate);
            buildingData.units.Add(newResidentialUnit);
          Debug.Log("fabricateBuilding");
        }
        for (int i = 0; i < commercialUnits; i++)
        {
            CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
            buildingData.units.Add(newCommercialUnit);
        }
        //  Debug.Log("fabricateBuilding");

        uiController.SetPlaceableObject(residentialBuildingPrefab, EntityFactory.EntityType.Building, BuildingType.Residential1, buildingData);
    }

}
