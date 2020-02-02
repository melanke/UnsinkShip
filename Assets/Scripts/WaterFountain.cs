using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFountain : MonoBehaviour
{

    private int indexSpawnPoint;

    private DangerLevelShip dangerLevelShip;
    private SpawnerWaterFountain spawnerWaterFountain;

    public DangerLevelShip DangerLevelShip { get => dangerLevelShip; set => dangerLevelShip = value; }
    public SpawnerWaterFountain SpawnerWaterFountain { get => spawnerWaterFountain; set => spawnerWaterFountain = value; }
    public int IndexSpawnPoint { get => indexSpawnPoint; set => indexSpawnPoint = value; }

    public void EnableSpawnPoint()
    {
        spawnerWaterFountain.EnableSpawnPoint(indexSpawnPoint);
    }
}
