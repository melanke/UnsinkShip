using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSound : MonoBehaviour
{


    public void PlaySmash()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
}
