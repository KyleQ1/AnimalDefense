using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int amount = 0;

    void Start()
    {
        UpdateText();
    }


    void UpdateText()
    {
        text.text = "Money: " + amount.ToString();
    }

    [ContextMenu("Add 100")]
    public void addMoney()
    {
        changeMoney(-100);
    }

    public void changeMoney(int price)
    {
        amount -= price;
        UpdateText();
    }
}
