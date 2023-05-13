using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropImage : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler

{
    public bool containsBuilding = false;
    public Button buildButton;
    public BuildingTemplateCreation buildingTemplateCreation;
    public int currentBuildingIcon;
    
    public Building building;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            containsBuilding = true;
            buildButton.gameObject.SetActive(true);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            buildingTemplateCreation.buildingData[currentBuildingIcon] = eventData.pointerDrag.GetComponent<Building>();
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<CanvasGroup>().alpha = 0.8f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<CanvasGroup>().alpha = 0.6f;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse clicked!");
    }
}
