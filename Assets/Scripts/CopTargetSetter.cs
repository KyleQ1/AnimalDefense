using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class CopTargetSetter : MonoBehaviour
{
    AIDestinationSetter destinationSetter;
    Health health;
    public GameObject money;
    public int monetaryValue = 5;

    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        health = GetComponent<Health>();
        money = GameObject.Find("Money");

        destinationSetter.target = GameObject.Find("racecar").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            float damage = 50f;
            bool died = health.TakeDamage(damage);
            if (died)
            {
                money.GetComponent<MoneyCounter>().addMoney(monetaryValue);
            }
            Destroy(collision.gameObject);
        }
    }
}
