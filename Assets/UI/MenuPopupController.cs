using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuPopupController : MonoBehaviour
{
    public GameObject menuPopup;
    public LayerMask buildingLayer;
    public Camera mainCamera;
    public TextMeshProUGUI entityName;
    public TextMeshProUGUI resUnits;
    public TextMeshProUGUI comUnits;

    [SerializeField] private RectTransform menuPopupRectTransform;

    public void ShowMenuPopup(bool show, Vector3 position)
    {
        menuPopup.SetActive(show);

        if (show)
        {
            Vector3 offset = new Vector3(0, menuPopupRectTransform.rect.height * 0.5f * 0.01f, 0);
            menuPopup.transform.position = position + offset;
        }
    }


    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingLayer))
        {
            ShowMenuPopup(true, hit.point);
            GameObject hitObject = hit.collider.gameObject;
            
            BuildingData buildingData = hitObject.GetComponent<Building>().data;
            entityName.SetText(buildingData.buildingName);
            resUnits.SetText("Residential Units: " + buildingData.GetUnitCountByType(UnitData.UnitType.Residential));
            comUnits.SetText("Commercial Units: " + buildingData.GetUnitCountByType(UnitData.UnitType.Commercial));

        }
        else
        {
            ShowMenuPopup(false, Vector3.zero);
        }
    }

}
