using UnityEngine;
using System.Collections.Generic;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }
    
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private int monstersPerStage = 5;
    
    private List<Monster> activeMonsters = new List<Monster>();
    private MapGenerator mapGenerator;
    
    private void Awake()
    {
        Instance = this;
        mapGenerator = GetComponent<MapGenerator>();
    }
    
    private void Start()
    {
        SpawnMonstersForStage();
    }
    
    private void SpawnMonstersForStage()
    {
        for (int i = 0; i < monstersPerStage; i++)
        {
            Vector3 randomPos = GetRandomSpawnPosition();
            GameObject monsterObj = Instantiate(monsterPrefab, randomPos, Quaternion.identity);
            Monster monster = monsterObj.GetComponent<Monster>();
            activeMonsters.Add(monster);
        }
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        // 맵 내의 랜덤한 위치 반환
        float x = Random.Range(1, mapGenerator.mapWidth - 1);
        float z = Random.Range(1, mapGenerator.mapLength - 1);
        return new Vector3(x, 1, z);
    }
    
    public void MonsterDefeated(Monster monster)
    {
        activeMonsters.Remove(monster);
        
        if (activeMonsters.Count == 0)
        {
            StageCleared();
        }
    }
    
    private void StageCleared()
    {
        Debug.Log("Stage Cleared!");
        // 다음 스테이지로 진행하는 로직 추가
    }
}