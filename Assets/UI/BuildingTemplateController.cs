using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTemplateController : MonoBehaviour
{
    public GameObject unitPrefab;
    public float columnSpacing = 0.185f;
    public float rowSpacing = 0.0378f;
    public int maxUnitsPerRow = 5;

    private int _residentialUnits;
    private int _commercialUnits;
    private List<GameObject> residentialUnits = new List<GameObject>();
    private List<GameObject> commercialUnits = new List<GameObject>();

    public int ResidentialUnits
    {
        get { return _residentialUnits; }
        set
        {
            _residentialUnits = value;
            UpdateResidentialUnits();
        }
    }

    public int CommercialUnits
    {
        get { return _commercialUnits; }
        set
        {
            _commercialUnits = value;
            UpdateCommercialUnits();
        }
    }

    private void UpdateResidentialUnits()
    {
        UpdateUnits(ref residentialUnits, ResidentialUnits, Color.green);
    }

    private void UpdateCommercialUnits()
    {
        UpdateUnits(ref commercialUnits, CommercialUnits, Color.blue);
    }

  private void UpdateUnits(ref List<GameObject> unitList, int newCount, Color unitColor)
{
    // Remove extra units
    while (unitList.Count > newCount)
    {
        GameObject unitToRemove = unitList[unitList.Count - 1];
        unitList.RemoveAt(unitList.Count - 1);
        Destroy(unitToRemove);
    }

    // Add new units
    while (unitList.Count < newCount)
    {
        // Calculate the row and column for this unit
        int i = residentialUnits.Count + commercialUnits.Count;
        int row = i / maxUnitsPerRow;
        int column = i % maxUnitsPerRow;

        // Calculate the position for this unit
        Vector3 position = new Vector3(column * columnSpacing, row * rowSpacing, 0);

        // Instantiate the unit
        GameObject unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);

        unitList.Add(unit);
    }

    // Redraw all units
    RedrawAllUnits();
}

private void RedrawAllUnits()
{
    // Combine the lists of units
    List<GameObject> allUnits = new List<GameObject>(residentialUnits);
    allUnits.AddRange(commercialUnits);

    // Sort the units by their current position
    allUnits.Sort((a, b) =>
    {
        int rowA = (int)(a.transform.position.y / rowSpacing);
        int rowB = (int)(b.transform.position.y / rowSpacing);
        int columnA = (int)(a.transform.position.x / columnSpacing);
        int columnB = (int)(b.transform.position.x / columnSpacing);

        if (rowA == rowB)
        {
            return columnA - columnB;
        }
        else
        {
            return rowA - rowB;
        }
    });

    // Redraw the units
    for (int i = 0; i < allUnits.Count; i++)
    {
        // Calculate the row and column for this unit
        int row = i / maxUnitsPerRow;
        int column = i % maxUnitsPerRow;

        // Calculate the position for this unit
        Vector3 position = new Vector3(column * columnSpacing, row * rowSpacing, 0);

        // Set the position of the unit
        GameObject unit = allUnits[i];
        unit.transform.position = position;
    }
}



    




}
