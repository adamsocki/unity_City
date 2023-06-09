using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingCreationController : MonoBehaviour
{
    public BuildingTemplateController buildingTemplateController;


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

    public GameObject buildingTemplateIconPrefab;
    public Button buildingTemplateForgeButton;

    private bool isOpen = false;
    public Image buildingTemplate;

    public BuildingTemplateCreation buildingTemplateContainer;


    public bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            buildingTemplate.gameObject.SetActive(isOpen);
        }
    }

    // Code so that isOpen to set gameObject.SetActive(isOpen)



    // add listeners to all the buttons
    public void InitBuildingCreationController()
    {
       
        if (buildingType == BuildingType.Residential1)
        {
            addResidentialUnitButton.onClick.AddListener(AddResidentialUnit);
            removeResidentialUnitButton.onClick.AddListener(RemoveResidentialUnit);
            addCommercialUnitButton.onClick.AddListener(AddCommercialUnit);
            removeCommercialUnitButton.onClick.AddListener(RemoveCommercialUnit);
            buildingTemplateForgeButton.onClick.AddListener(ForgeBuildingTemplateIcon);

            UpdateUnitTexts();
        }
        generateBuildingName.onClick.AddListener(GenerateBuildingName);

        initNewBuildingButton.onClick.AddListener(InitNewBuilding);
        fabricateNewBuildingButton.onClick.AddListener(FabricateNewBuilding);
        
        // debug line above
        

    }

    [SerializeField] private GameObject imagePrefab;

    private GameObject newBuildingTemplateIcon;

    private void ForgeBuildingTemplateIcon()
    {
        newBuildingTemplateIcon = Instantiate(imagePrefab);

        // Assuming the parent is a Canvas or another UI element
        newBuildingTemplateIcon.transform.SetParent(buildingTemplateContainer.transform, false);
        RectTransform rectTransform = newBuildingTemplateIcon.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(281.9f, -186.0f, -0.15f); // Center of the parent
        newBuildingTemplateIcon.GetComponent<DragImage>().initialPosition = rectTransform.anchoredPosition;
        //newBuildingTemplateIcon.transform.position = new Vector3(281.9f, -186.0f, -0.15f)

        //GameObject newBuildingTemplateIcon = Instantiate(buildingTemplateIconPrefab);
        //newBuildingTemplateIcon.SetActive(true);
        //newBuildingTemplateIcon.transform.position = new Vector3(0,0,0);






        BuildingData residential1BuildingData = ScriptableObject.CreateInstance<BuildingData>();
        CostModifierData newInitialCost = ScriptableObject.CreateInstance<CostModifierData>();


        residential1BuildingData.buildingName = buildingName.text;
        residential1BuildingData.CostModifierData = newInitialCost;
        residential1BuildingData.ModifyInitialCost((residentialUnits * 10) + (commercialUnits * 20));


        newBuildingTemplateIcon.GetComponent<Building>().data = residential1BuildingData;
        newBuildingTemplateIcon.GetComponent<Building>().totalResidentialUnits = residentialUnits;
        newBuildingTemplateIcon.GetComponent<Building>().totalCommercialUnits = commercialUnits;

        residentialUnits = 0;
        commercialUnits = 0;
    }


    private void GenerateBuildingName()
    {
        buildingName.text = buildingNameGenerator.GenerateRandomName(buildingType);
    }

    private void AddResidentialUnit()
    {
        residentialUnits++;
        buildingTemplateController.ResidentialUnits = residentialUnits;
        UpdateUnitTexts();
    }

    private void RemoveResidentialUnit()
    {
        if (residentialUnits > 0)
        {
            residentialUnits--;
            buildingTemplateController.ResidentialUnits = residentialUnits;
            UpdateUnitTexts();
        }
    }

    private void AddCommercialUnit()
    {
        commercialUnits++;
        buildingTemplateController.CommercialUnits = commercialUnits;
        UpdateUnitTexts();
    }

    private void RemoveCommercialUnit()
    {
        if (commercialUnits > 0)
        {
            commercialUnits--;
            buildingTemplateController.CommercialUnits = commercialUnits;
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
                    residential1BuildingData.AddUnit(newResidentialUnit);
                }

                for (int i = 0; i < commercialUnits; i++)
                {
                    CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
                    residential1BuildingData.AddUnit(newCommercialUnit);
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
