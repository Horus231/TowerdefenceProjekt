using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;   // The prefab of the monster to be spawned
    public float spawnInterval = 5f;   // Time interval between monster spawns in seconds

    void Start()
    {
        // Start the coroutine to spawn monsters periodically
        StartCoroutine(SpawnMonstersPeriodically());
    }

    IEnumerator SpawnMonstersPeriodically()
    {
        while (true)
        {
            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Spawn a monster at the current position of the spawner
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }
}
