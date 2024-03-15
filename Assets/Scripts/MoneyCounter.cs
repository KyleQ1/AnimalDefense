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
        addMoney(100);
    }

    public void addMoney(int price)
    {
        amount += price;
        UpdateText();
    }
    public void buy(int price)
    {
        amount -= price;
        UpdateText();
    }
}
