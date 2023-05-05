using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ExpandableMenuController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    public Button expandButton;
    public Animator subMenuAnimator;
    public List<GameObject> subMenuButtons;
    public GameObject panel; 
    public Button panelButton; 

    private bool isExpanded;

    public void InitExpandableMenuController()
    {
        isExpanded = false;
        expandButton.onClick.AddListener(ToggleExpand);
    //    panelButton.onClick.AddListener(PanelButtonClicked);
    }

    private void ToggleExpand()
    {
        isExpanded = !isExpanded;
        subMenuAnimator.SetBool("Expand", isExpanded);
        print("isExpanded is: " + isExpanded);
    }

    public bool GetIsExpanded()
    {
        return isExpanded;
    }

    public void SetIsExpanded(bool value)
    {
        isExpanded = value;
    }

            
    // This method is called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse entered the button.");
        if (subMenuAnimator != null && !panel.activeSelf)
        {
            panel.SetActive(true);
           // subMenuAnimator.SetBool("isCollapsed", true);
        }
    }

    // This method is called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isExpanded && subMenuAnimator != null)
        {
            panel.SetActive(false);
        }
    }



    private void PanelButtonClicked()
    {
        panel.SetActive(false);
        isExpanded = false;
    }



    public void UpdateExpandableMenuController()
    {
        if (panel != null)
        {
            if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space ))
            {
                ToggleExpand();
            }
        }
    }
}