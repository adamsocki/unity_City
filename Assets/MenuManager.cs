using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // create a list for my ExpandableMenuControllers
    public List<ExpandableMenuController> expandableMenuControllers;

    public void InitMenuManager()
    {
        // iterate through expandableMenuControllers and call InitExpandableMenuController
        foreach (ExpandableMenuController expandableMenuController in expandableMenuControllers)
        {
            expandableMenuController.InitExpandableMenuController();
        }

    }

    public void UpdateMenuManager()
    {
        // iterate through expandableMenuControllers and call UpdateExpandableMenuController
        foreach (ExpandableMenuController expandableMenuController in expandableMenuControllers)
        {
            expandableMenuController.UpdateExpandableMenuController();
        }
    }


    public void DisableExpandedMenus()
    {
        // iterate through expandableMenuControllers and call DisableExpandedMenu
        foreach (ExpandableMenuController expandableMenuController in expandableMenuControllers)
        {
            expandableMenuController.SetIsExpanded(false);
        }
    }
}
