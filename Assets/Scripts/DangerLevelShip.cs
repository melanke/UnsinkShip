using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class DangerLevelShip : MonoBehaviour
{

    [SerializeField] int dangerLevel;
    [SerializeField] int dangerLevelRepared = 3;
    [SerializeField] int maxDangerLevel;
    [SerializeField] int minDangerLevel = -50;


    [SerializeField] int tickTime = 1;

    int waterFountaisRepared;

    [Header("UI GameOver")]
    [SerializeField] GameObject panelGameOver;
    [SerializeField] Text countFloodSolved;
    [SerializeField] ChangeSceneByAnyKey changeSceneByAnyKey;
    [SerializeField] Text pressAnyKey;
    [SerializeField] float canRestartTime = 2f;

    // Perdendo >>> -1 * num de vazamentos 
    // Sobrevivendo >> +1
    int dangerIncrementer;

    List<WaterFountain> waterFountains = new List<WaterFountain>();

    public int DangerLevel { get => dangerLevel; set => dangerLevel = value; }

    private void Start()
    {
        StartCoroutine(ApplyDangerIncrementer());

        GameGlobals.paused = false;

    }


    private IEnumerator ApplyDangerIncrementer()
    {
        while (true)
        {

            DangerLevel = Math.Min(DangerLevel + dangerIncrementer, maxDangerLevel);

            if(DangerLevel <= minDangerLevel)
            {
                GameOver();
            }

            yield return new WaitForSeconds(tickTime);
        }
    }

    private void GameOver()
    {
        // TODO aparecer GUI com quantidades de vazementos tratado
        //panelGameOver.SetActive(true);

        ShowGameOverUI();

        PauseComponents();

    }

    private void ShowGameOverUI()
    {
        panelGameOver.SetActive(true);
        countFloodSolved.text = waterFountaisRepared.ToString();

        StartCoroutine(CanChangeScene());
    }

    IEnumerator CanChangeScene()
    {

        yield return new WaitForSecondsRealtime(canRestartTime);

        changeSceneByAnyKey.gameObject.SetActive(true);
        pressAnyKey.gameObject.SetActive(true);

    }

    private static void PauseComponents()
    {
        foreach (ThirdPersonUserControl tp in FindObjectsOfType<ThirdPersonUserControl>())
        {
            tp.PausePerson();
        }

        GameGlobals.paused = true;
    }

    private void Update()
    {

        if(waterFountains.Count == 0)
        {
            dangerIncrementer = 1;
        }
        else
        {
            dangerIncrementer = waterFountains.Count * -1;
        }
    }

    public void AddWaterFountain(WaterFountain waterFountain)
    {
        waterFountains.Add(waterFountain);

    }


    public void RemoveWaterFountain(WaterFountain waterFountain)
    {

        waterFountaisRepared++;

        waterFountains.Remove(waterFountain);
    }

}
