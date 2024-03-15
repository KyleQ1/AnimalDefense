using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject spawner;
    bool inWave = true;
    int counter;

    void Start()
    {
    }


    void Update()
    {
        inWave = !spawner.GetComponent<WaveSpawner>().readyForWave;
        if (inWave)
        {
            text.text = "";
        } else
        {
            counter = (int) spawner.GetComponent<WaveSpawner>().countdown;
            text.text = "Next wave in: " + counter.ToString();
        }
    }
}
