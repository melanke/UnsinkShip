using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private bool displayLabel = false;

    [SerializeField] private string textToBlink;



    void Start()
    {
        
        StartCoroutine(FlashLabel());
    }

    IEnumerator FlashLabel()
    {

        // Fancy pants flash of label on and off   
        while (true)
        {
            displayLabel = true;
             yield return new WaitForSeconds(.5f);
            displayLabel = false;
             yield return new WaitForSeconds(.5f);
        }

    }

    void OnGUI()
    {

        if (displayLabel == true)
            this.gameObject.GetComponent<Text>().text = textToBlink;
        else
        {
            this.gameObject.GetComponent<Text>().text = "";
        }

    }
}
