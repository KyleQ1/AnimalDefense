using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject spawner;
    public bool inWave;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if you are in build or attack phase
        inWave = !spawner.GetComponent<WaveSpawner>().readyForWave;

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire){
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring){
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && inWave){
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }

    }
}
