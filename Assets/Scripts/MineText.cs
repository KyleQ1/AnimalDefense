using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MineText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject priceScript;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();

    }

    void UpdateText()
    {
        text.text = "Mine: " + priceScript.GetComponent<towerSpawn>().price.ToString();
    }
}
