using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class TerratinGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrains = new List<TerrainData>();
    private int maxTerrainCount;
    [SerializeField] private Transform terrainHolder;
    [SerializeField] private Transform playerPos;

    private Vector3 currentPos = new Vector3(0, 0, 0);
    [SerializeField] private List<GameObject> currentTerrains = new List<GameObject>();

    private int previousTerrain = -1;

    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        maxTerrainCount = 25;
        SpawnFirstTerrain();
    }

    void Update()
    {
        if (playerPos != null)
        {
            if (currentPos.x - playerPos.position.x < 15)
            {
                Destroy(currentTerrains[0]);
                currentTerrains.RemoveAt(0);
                SpawnAfter();
            }
        }
    }

    private void SpawnTerrain()
    {
        int whichTerrain = Random.Range(0, terrains.Count);

        while (previousTerrain == whichTerrain)
        {
            whichTerrain = Random.Range(0, terrains.Count);
        }

        previousTerrain = whichTerrain;

        int terrainInSuccession = Random.Range(1, terrains[whichTerrain].maxInSuccession + 1);

        for (int j = 0; j < terrainInSuccession; j++)
        {
            if (currentTerrains.Count < maxTerrainCount)
            {
                int terrainVariant = Random.Range(0, terrains[whichTerrain].possibleTerrains.Count);
                GameObject terrain = Instantiate(terrains[whichTerrain].possibleTerrains[terrainVariant], currentPos, Quaternion.identity, terrainHolder);
                //GameObject terrain = objectPooler.SpawnFromPool(terrains[0].possibleTerrains[terrainVariant].name, currentPos, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                currentPos.x++;

            }
        }
    }

    private void SpawnFirstTerrain()
    {
        int terrainInSuccession = Random.Range(1, terrains[0].maxInSuccession + 1);

        for (int j = 0; j < terrainInSuccession; j++)
        {
            if (currentTerrains.Count < maxTerrainCount)
            {
                int terrainVariant = Random.Range(0, terrains[0].possibleTerrains.Count);
                GameObject terrain = Instantiate(terrains[0].possibleTerrains[terrainVariant], currentPos, Quaternion.identity, terrainHolder);
                //GameObject terrain = objectPooler.SpawnFromPool(terrains[0].possibleTerrains[terrainVariant].name, currentPos, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                currentPos.x++;
            }
        }

        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }
    }

    private void SpawnAfter()
    {
        int whichTerrain = Random.Range(0, terrains.Count);
        int terrainInSuccession = Random.Range(1, terrains[whichTerrain].maxInSuccession + 1);

        for (int j = 0; j < terrainInSuccession; j++)
        {
            if (currentTerrains.Count < maxTerrainCount)
            {
                int terrainVariant = Random.Range(0, terrains[whichTerrain].possibleTerrains.Count);
                GameObject terrain = Instantiate(terrains[whichTerrain].possibleTerrains[terrainVariant], currentPos, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                currentPos.x++;

            }
        }
    }
}
