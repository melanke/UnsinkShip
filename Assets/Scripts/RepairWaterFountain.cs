using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(WaterFountain))]
public class RepairWaterFountain : MonoBehaviour
{

    [SerializeField] int dangerLevel = 1;
    [SerializeField] int dangerLevelRepared = 0;
    [SerializeField] int maxDangerLevel = 6;
   
    [SerializeField] int startSpeedMax = 8;
    [SerializeField] int startSpeedMin = 0;

    [SerializeField] int emissionRateMax = 50;
    [SerializeField] int emissionRateMin = 0;

    int dangerIncrementer = +1;

    Smash smashComponent;

    private void Start()
    {
        StartCoroutine(ApplyDangerIncrementer());
    }
    

    private IEnumerator ApplyDangerIncrementer()
    {
        while (true)
        {
            if(dangerLevel < maxDangerLevel || dangerIncrementer == -1)
            {
                dangerLevel += dangerIncrementer;

                ModifyParticle();
            }
            if(dangerLevel < dangerLevelRepared)
            {
                WaterFountainRepared();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void ModifyParticle()
    {
        float steps = Math.Abs(maxDangerLevel - dangerLevelRepared);
        gameObject.GetComponent<ParticleSystem>().startSpeed = ((startSpeedMax - startSpeedMin) / steps * dangerLevel) + startSpeedMin;

        gameObject.GetComponent<ParticleSystem>().emissionRate = ((emissionRateMax - emissionRateMin) / steps * dangerLevel) + emissionRateMin;

    }



    private void OnTriggerEnter(Collider other)
    {
        smashComponent = other.gameObject.GetComponent<Smash>();
        smashComponent.InWaterFoutain = true;

        smashComponent.pressEToRepairText.gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Smash>() != null)
        {
            smashComponent.pressEToRepairText.gameObject.SetActive(false);
            smashComponent.InWaterFoutain = false;
            smashComponent = null;
        }
    }


    private void Update()
    {
        if (smashComponent != null && smashComponent.Smashing)
        {
            dangerIncrementer = -1;
        }
        else {
            dangerIncrementer = +1;
        }

    }



    private void WaterFountainRepared()
    {
        // TODO animar e destruir


        WaterFountain wf = gameObject.GetComponent<WaterFountain>();

        wf.DangerLevelShip.RemoveWaterFountain(wf);

        wf.EnableSpawnPoint();

        smashComponent.pressEToRepairText.gameObject.SetActive(false);
        //smashComponent.InWaterFoutain = false;

        Destroy(gameObject);
    }
}
