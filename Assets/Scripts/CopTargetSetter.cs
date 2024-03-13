using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class CopTargetSetter : MonoBehaviour
{
    AIDestinationSetter destinationSetter;
    Health health;
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        health = GetComponent<Health>();
        destinationSetter.target = GameObject.Find("racecar").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            float damage = 50f;
            health.TakeDamage(damage);
            Destroy(collision.gameObject);
        }
    }
}
