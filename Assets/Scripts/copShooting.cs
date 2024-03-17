using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform characterTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the rotation of the bullet to the rotation of the player
        transform.rotation = characterTransform.rotation;

        if (!canFire){
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring) {
                canFire = true;
                timer = 0;
            }
        }

        if (canFire) {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, transform.rotation);
            Vector2 bulletDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector2.up;
            bullet.GetComponent<bulletscript>().SetDirection(bulletDirection);
        }
    }
}
