using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject priceScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        string price = priceScript.GetComponent<SMGUpgrade>().price.ToString();
        int level = priceScript.GetComponent<SMGUpgrade>().level;
        string lv;
        if (level == 4)
        {
            text.text = "Max Level";
        } else
        {
            lv = "(Level " + level.ToString() + ")";
            text.text = "Upgrade Gun: " + price + "\n" + lv;
        }
       

    }
}
