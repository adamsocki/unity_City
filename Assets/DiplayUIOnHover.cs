using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiplayUIOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject panel; // Assign the panel in the Inspector
 //   public GameObject menuPanel;

    // This method is called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
        Debug.Log("Over");
    }

    // This method is called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
        Debug.Log("Off");
    }
}
