using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middleman : MonoBehaviour
{

    public void AdjustVolume(float newVolume)
    {
        AudioManager.instance.adjustVolume(newVolume);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
