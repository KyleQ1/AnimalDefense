using UnityEngine;
using UnityEngine.AI;

public class CopSpawner : MonoBehaviour
{
    public GameObject copPrefab;
    public Transform racecar;
    public float spawnInterval = 5f;
    public int copsPerWave = 3;

    private float timeSinceLastSpawn;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnInterval)
        {
            timeSinceLastSpawn = 0f;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < copsPerWave; i++)
        {
            Vector3 spawnPosition = RandomPositionOutsideView();
            GameObject cop = Instantiate(copPrefab, spawnPosition, Quaternion.identity);
            CopAI agent = cop.GetComponent<CopAI>();
            if (agent != null)
            {
                agent.racecar = racecar;
            }
        }
    }

    Vector3 RandomPositionOutsideView()
    {

        float radius = 10f;
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return racecar.position + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}
