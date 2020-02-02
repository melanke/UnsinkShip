using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smash : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] public Text pressEToRepairText;

    [SerializeField] string smashInput;

    private bool inWaterFoutain;

    public bool Smashing { get => Input.GetButton(smashInput); }
    public bool InWaterFoutain { get => inWaterFoutain; set => inWaterFoutain = value; }

    // Update is called once per frame
    void Update()
    {
        if(!GameGlobals.paused && InWaterFoutain)
        {
            GetComponent<Animator>().SetBool("Smashing", Smashing);
        }

    }
}
