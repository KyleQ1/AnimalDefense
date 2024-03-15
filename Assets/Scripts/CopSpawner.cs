using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject copPrefab;
    public float spawnDistance = 20f;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    private int waveNumber = 1;
    public bool readyForWave;

    void Update()
    {
        readyForWave = checkWaveCompletion();
        if (readyForWave)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        Vector2 spawnDirection = RandomDirectionOutsideView();
        for (int i = 0; i < waveNumber * 4; i++)
        {
            Vector2 spawnPosition = CalculateSpawnPosition(spawnDirection, i);
            if (!Physics2D.OverlapCircle(spawnPosition, 1f, LayerMask.GetMask("Obstacle")))
            {
                Instantiate(copPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    Vector2 RandomDirectionOutsideView()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        return direction;
    }

    Vector2 CalculateSpawnPosition(Vector2 direction, int index)
    {
        Vector2 offset = direction * spawnDistance + direction * index * 2f; 
        Vector2 spawnPosition = Camera.main.transform.position + (Vector3) offset;

        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -40, 40);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, -40, 40);

        return spawnPosition;
    }

    bool checkWaveCompletion()
    {
        GameObject cop = GameObject.Find("guncop(Clone)");
        if (cop == null)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
