using UnityEngine;

public class BuildingNameGenerator : MonoBehaviour
{


    private string[] portNames = {
    "Plymouth Rock",
    "Roanoke",
    "Jamestown",
    "Sutter's Mill",
    "Gettysburg",
    "Ellis Island",
    "Alcatraz",
    "Little Bighorn",
    "Wounded Knee",
    "Appomattox Court House",
    "Manhattan Project",
    "Bikini Atoll",
    "Pearl Harbor",
    "Dealey Plaza",
    "Three Mile Island",
    "Kent State",
    "Watergate",
    "Love Canal",
    "Ruby Ridge",
    "Waco",
    "Oklahoma City",
    "World Trade Center",
    "Katrina",
    "Ferguson",
    "Flint",
    "Standing Rock"
};
    
    private string[] prefixes;
    private string[] adjectives;
    private string[] nouns;
    private string[] suffixes;
    private string[] firstNames;
    private string[] lastNames;
    private string[] locations;

    // Name generation weights
    public float[] weights = { 1, 1, 1, 1, 1, 1, 1, 1 };
    public float[] weightsPOE = { 1, 1, 1, 1};


    void Start()
    {
        LoadNameParts();

    }

    // =================================
    // =================================
    // SECTION 1: GENERAL CODE
    // =================================
    // =================================

    private void LoadNameParts()
    {
        prefixes = LoadTextFile("prefixes");
        adjectives = LoadTextFile("adjectives");
        nouns = LoadTextFile("nouns");
        suffixes = LoadTextFile("suffixes");
        firstNames = LoadTextFile("firstNames");
        lastNames = LoadTextFile("lastNames");
        locations = LoadTextFile("locations");
    }


    private string[] LoadTextFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("WordLists/" + fileName);
        if (textAsset != null)
        {
            return textAsset.text.Split('\n');
        }
        else
        {
            Debug.LogError("File not found: " + fileName);
            return new string[0];
        }
    }


    private int GetWeightedRandom(float[] weights)
    {
        float totalWeight = 0;
        foreach (float weight in weights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float weightSum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            weightSum += weights[i];
            if (randomValue < weightSum)
            {
                return i + 1;
            }
        }

        return 1;
    }


    // ENTRY CODE FOR CLASS
    public string GenerateRandomName(BuildingType buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.PortOfEntry:
                return GeneratePortOfEntryName();
            case BuildingType.Residential1:
                return GenerateResidentialBuildingName();
            default:
                return "Unkown";
        }

    }


    // =================================
    // =================================
    // SECTION 2: PORT OF ENTRY CODE
    // =================================
    // =================================

    private string GeneratePortOfEntryName()
    {
        int nameType = GetWeightedRandom(weightsPOE);

        switch (nameType)
        {
            case 0:
                return GeneratePortType1();
            case 1:
                return GeneratePortType2();
            case 2:
                return GeneratePortType3();
            case 3:
                return GeneratePortType4();
            default:
                return "Unnamed Port";
        }
    }

    private string GeneratePortType1()
    {
        string portName = portNames[Random.Range(0, portNames.Length)];
        return portName;
    }

    private string GeneratePortType2()
    {
        string prefix = prefixes[Random.Range(0, prefixes.Length)];
        string portName = portNames[Random.Range(0, portNames.Length)];

        return string.Format("{0} {1}", prefix, portName).Trim();
    }

    private string GeneratePortType3()
    {
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];
        string portName = portNames[Random.Range(0, portNames.Length)];

        return string.Format("{0} {1}'s {2}", firstName, lastName, portName).Trim();
    }

    private string GeneratePortType4()
    {
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string portName = portNames[Random.Range(0, portNames.Length)];

        return string.Format("{0} {1}", adjective, portName).Trim();
    }


    // =================================
    // =================================
    // SECTION 2: RESIDENTIAL CODE
    // =================================
    // =================================


    private string GenerateResidentialBuildingName()
    {
        int nameType = GetWeightedRandom(weights);

        switch (nameType)
        {
            case 1:
                return GenerateType1();
            case 2:
                return GenerateType2();
            case 3:
                return GenerateType3();
            case 4:
                return GenerateType4();
            case 5:
                return GenerateType5();
            case 6:
                return GenerateType6();
            case 7:
                return GenerateType7();
            case 8:
                return GenerateType8();
            default:
                return "Unknown";
        }
    }


    private string GenerateType1()
    {
        string prefix = prefixes[Random.Range(0, prefixes.Length)];
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];
        string suffix = suffixes[Random.Range(0, suffixes.Length)];

        return string.Format("{0} {1} {2} {3}", prefix, adjective, noun, suffix).Trim();
    }

    private string GenerateType2()
    {
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];

        return string.Format("{0} {1}", adjective, noun).Trim();
    }

    private string GenerateType3()
    {
        string noun = nouns[Random.Range(0, nouns.Length)];
        string suffix = suffixes[Random.Range(0, suffixes.Length)];

        return string.Format("{0} {1}", noun, suffix).Trim();
    }

    private string GenerateType4()
    {
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];

        return string.Format("{0} {1} {2}", firstName, lastName, noun).Trim();
    }

    private string GenerateType5()
    {
        string noun = nouns[Random.Range(0, nouns.Length)];
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string noun2 = nouns[Random.Range(0, nouns.Length)];

        return string.Format("{0} of {1} {2}", noun, adjective, noun2).Trim();
    }

    private string GenerateType6()
    {
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];

        return string.Format("{0} {1} by {2} {3}", adjective, noun, firstName, lastName).Trim();
    }

    private string GenerateType7()
    {
        string location = locations[Random.Range(0, locations.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];

        return string.Format("{0} {1}", location, noun).Trim();
    }

    private string GenerateType8()
    {
        string noun = nouns[Random.Range(0, nouns.Length)];
        string location = locations[Random.Range(0, locations.Length)];

        return string.Format("{0} at {1}", noun, location).Trim();
    }

    

}
