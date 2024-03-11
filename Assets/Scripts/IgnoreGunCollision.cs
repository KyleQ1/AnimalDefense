using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGunCollision : MonoBehaviour
{
    public Collider2D car;
    public Collider2D gun;

    void Start()
    {
        Physics2D.IgnoreCollision(car, gun, true);
    }

}
