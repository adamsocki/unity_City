using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuPopupController : MonoBehaviour
{
    public GameObject menuPopup;
    public LayerMask buildingLayer;
    public Camera mainCamera;
    public Text buildingName;

 

    public void ShowMenuPopup(bool show, Vector3 position)
    {
        menuPopup.SetActive(show);

        if (show)
        {
            menuPopup.transform.position = position;
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
           // if ()
            //BuildingController buildingController = hitObject.GetComponent<BuildingController>();
            //if (buildingController != null)
            //{

            //   //// Debug.Log("THis is a building");
            //   // buildingName.text = buildingController.buildingData.buildingName;
            //}

            buildingName.text = hitObject.GetComponent<Building>().data.buildingName;

        }
        else
        {
            ShowMenuPopup(false, Vector3.zero);
        }
    }

}
