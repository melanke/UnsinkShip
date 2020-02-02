using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWaterFountain : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] int maxSpawnInLevel;
    [SerializeField] float spawnIntervalTime;
    [SerializeField] GameObject waterFountainPrefab;
    [SerializeField] DangerLevelShip dangerLevelShipObj;


    private ArrayList sortedIndexes = new ArrayList();
    private int spawnCreated;

    void Start()
    {
        Invoke("Spawn", spawnIntervalTime);
    }

    void Spawn()
    {
        // Existe algum spawn sem vazamento
        Debug.Log(sortedIndexes.Count);
        if(sortedIndexes.Count < spawnPoints.Length)
        {


            // Choose random spawn
            int indexSorted;
            do
            {
                indexSorted = UnityEngine.Random.Range(0, spawnPoints.Length);
            } while (sortedIndexes.Contains(indexSorted));

            Transform localSpawn = spawnPoints[indexSorted];
            sortedIndexes.Add(indexSorted);

            GameObject waterFountainGM = Instantiate(waterFountainPrefab, localSpawn.position, waterFountainPrefab.transform.rotation);

            WaterFountain wf = waterFountainGM.GetComponent<WaterFountain>();

            wf.SpawnerWaterFountain = this;
            wf.IndexSpawnPoint = indexSorted;
            wf.DangerLevelShip = dangerLevelShipObj;

            dangerLevelShipObj.AddWaterFountain(wf);
             
            spawnCreated++;

        }
        Invoke("Spawn", spawnIntervalTime);
        
    }

    public void EnableSpawnPoint(int index)
    {
        sortedIndexes.Remove(index);
    }
}
