using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallText : MonoBehaviour
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
        text.text = "Wall: " + priceScript.GetComponent<WallSpawner>().price.ToString();
    }
}
