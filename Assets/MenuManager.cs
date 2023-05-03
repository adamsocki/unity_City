using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public ExpandableMenuController buildingExpandableMenuController;
    public ExpandableMenuController portOfEntryMenuController;
    public ExpandableMenuController residencyMenuController;

    public void InitMenuManager()
    {
        buildingExpandableMenuController.InitExpandableMenuController();
        portOfEntryMenuController.InitExpandableMenuController();
        residencyMenuController.InitExpandableMenuController();
    }
}
