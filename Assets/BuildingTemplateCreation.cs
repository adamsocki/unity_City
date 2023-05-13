using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.ObjectModel;

public class BuildingTemplateCreation : MonoBehaviour
{
    public Building[] buildingData = new Building[3];

    public GameObject residentialBuildingPrefab;
    public UIController uiController;


    public ResidentialUnit residentialUnitDataTemplate;
    public CommercialUnit commercialUnitDataTemplate;

    public Button buildingCreationButton1;
    public Button buildingCreationButton2;
    public Button buildingCreationButton3;


    public void FabricateBuilding(int buildingNumber)
    {




        BuildingData newResidentialBuildingData = ScriptableObject.CreateInstance<BuildingData>();
        newResidentialBuildingData = buildingData[buildingNumber].data.Clone();


        for (int i = 0; i < buildingData[buildingNumber].totalResidentialUnits; i++)
        {
            ResidentialUnit newResidentialUnit = Instantiate(residentialUnitDataTemplate);
            newResidentialBuildingData.AddUnit(newResidentialUnit);
        }
        
        for (int i = 0; i < buildingData[buildingNumber].totalCommercialUnits; i++)
        {
            CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
            newResidentialBuildingData.AddUnit(newCommercialUnit);
        }

        uiController.SetPlaceableObject(residentialBuildingPrefab, EntityFactory.EntityType.Building, BuildingType.Residential1, newResidentialBuildingData);
    }
    


    //public void TriggerOnPointerClick(PointerEventData eventData)
    //{
    //    var pointerClickEvent = eventData as UnityEngine.EventSystems.PointerClickEvent;
    //    if (pointerClickEvent != null)
    //    {
    //        buildingCreationButton1.OnPointerClick(pointerClickEvent);
    //        buildingCreationButton2.OnPointerClick(pointerClickEvent);
    //        buildingCreationButton3.OnPointerClick(pointerClickEvent);
    //    }
    //}




}
