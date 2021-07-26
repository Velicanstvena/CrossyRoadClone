using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private int minSpawnTime;
    [SerializeField] private int maxSpawnTime;
    [SerializeField] private bool isRightSide;

    private Transform obstaclesHolder;

    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;

        obstaclesHolder = GameObject.Find("Obstacles").transform;
        StartCoroutine(SpawnVehicle());
    }

    private IEnumerator SpawnVehicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GameObject newVehicle = objectPooler.SpawnFromPool(objectToSpawn.name, spawnPos.position, Quaternion.identity, obstaclesHolder);
            if (!isRightSide)
            {
                newVehicle.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
