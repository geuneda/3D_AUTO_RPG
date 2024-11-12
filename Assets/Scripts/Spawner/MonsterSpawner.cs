using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 2f, spawnInterval);
    }

    void SpawnMonster()
    {
        if (spawnPoints.Length == 0) return;
        
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}