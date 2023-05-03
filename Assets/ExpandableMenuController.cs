using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandableMenuController : MonoBehaviour
{
    public Button expandButton;
    public Animator subMenuAnimator;
    public List<GameObject> subMenuButtons;

    private bool isExpanded;

    public void InitExpandableMenuController()
    {
        isExpanded = false;
        expandButton.onClick.AddListener(ToggleExpand);
    }

    private void ToggleExpand()
    {
        isExpanded = !isExpanded;
        subMenuAnimator.SetBool("Expand", isExpanded);
        print("isExpanded is: " + isExpanded);
    }
}