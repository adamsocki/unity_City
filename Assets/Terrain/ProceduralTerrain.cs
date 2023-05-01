using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int depth = 20;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    public Material terrainMaterial;

    private void Start()
    {
        offsetX = Random.Range(0, 99999f);
        offsetY = Random.Range(0, 99999f);

        TerrainData terrainData = GenerateTerrainData();
        GenerateTerrain(terrainData);
    }

    private TerrainData GenerateTerrainData()
    {
        TerrainData terrainData = new TerrainData();
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeightMap());

        return terrainData;
    }

    private float[,] GenerateHeightMap()
    {
        float[,] heightMap = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale + offsetX;
                float yCoord = (float)y / height * scale + offsetY;

                heightMap[x, y] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }

        return heightMap;
    }

    private void GenerateTerrain(TerrainData terrainData)
    {
        Terrain terrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();
        terrain.materialTemplate = terrainMaterial;
    }
}
