using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownMenuController : MonoBehaviour
{
    public TMP_Dropdown dropDown;
   // public <List>TMP_Dropdown dropDownList;
    public bool isFilledByInspector;

    private Dictionary<int, string> buildingTypeLookup;

    public void Start()
    {
        dropDown.ClearOptions();

        List<string> options = new List<string> { "House", "Apartment", "Office", "Warehouse" };


        AddOptions(options);

        // Initialize lookup dictionary and populate it with data
        buildingTypeLookup = new Dictionary<int, string>();
        for (int i = 0; i < options.Count; i++)
        {
            buildingTypeLookup.Add(i, options[i]);
        }

        dropDown.onValueChanged.AddListener(delegate { BuildingSelected(); });

    }

    public void BuildingSelected()
    {
        int selectedIndex = dropDown.value;

        if (buildingTypeLookup.TryGetValue(selectedIndex, out string buildingType))
        {
            Debug.Log("Selected building type: " + buildingType);
        }
        else
        {
            Debug.LogError("No building type found for selected index: " + selectedIndex);
        }
    }


    public void AddOption(string newOption)
    {
        TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(newOption);
        dropDown.options.Add(optionData);
    }

    public void AddOptions(List<string> newOptions)
    {
        foreach(string newOption in newOptions) 
        {
            AddOption(newOption);
        }
    }


}
