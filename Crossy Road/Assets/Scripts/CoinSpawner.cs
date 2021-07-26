using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinToSpawn;
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private bool[] spawned;
    [SerializeField] private int minSpawnTime;
    [SerializeField] private int maxSpawnTime;
    private Transform coinsHolder;

    void Start()
    {
        spawned = new bool[spawnPos.Length];
        coinsHolder = GameObject.Find("Collectables").transform;
        StartCoroutine(SpawnVehicle());
    }

    private IEnumerator SpawnVehicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            int spawnerPos = Random.Range(0, spawnPos.Length);
            if (spawned[spawnerPos] == false)
            {
                GameObject newCoin = Instantiate(coinToSpawn, spawnPos[spawnerPos].position, Quaternion.identity, coinsHolder);
                spawned[spawnerPos] = true;
            }
        }
    }
}
