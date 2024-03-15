using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopVisibility : MonoBehaviour
{
    bool inWave;
    bool isVisible = false;
    public GameObject spawner;
    public GameObject shop;

    void Update()
    {
        inWave = !spawner.GetComponent<WaveSpawner>().readyForWave;
        if (inWave == isVisible)
        {
            isVisible = !isVisible;
            shop.SetActive(isVisible);
        }
    }
}
