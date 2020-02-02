using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWaterLevel : MonoBehaviour
{

    [SerializeField] DangerLevelShip dangerLevelShip;

    [SerializeField] float deltaStep;

    float yPosInicial;

    private void Start()
    {
        yPosInicial = GetComponent<Image>().rectTransform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 myPosition = GetComponent<Image>().rectTransform.position;

        float yPos = yPosInicial - (deltaStep * dangerLevelShip.DangerLevel);

        GetComponent<Image>().rectTransform.position = new Vector3(myPosition.x, yPos, myPosition.z);
    }
}