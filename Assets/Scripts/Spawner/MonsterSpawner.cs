using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // 스폰할 몬스터 프리팹
    public Transform[] spawnPoints; // 몬스터가 스폰될 지점들
    public float spawnInterval = 5f; // 몬스터가 스폰되는 시간 간격

    private StageManager stageManager;

    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        // 일정 시간마다 몬스터 스폰
        InvokeRepeating(nameof(SpawnMonster), 2f, spawnInterval);
    }

    void SpawnMonster()
    {
        if (spawnPoints.Length == 0) return;

        // 랜덤한 위치에서 몬스터 스폰
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);

        // 스테이지 매니저에 몬스터 등록
        if (stageManager != null)
        {
            stageManager.RegisterMonster(monster);
        }
    }
}