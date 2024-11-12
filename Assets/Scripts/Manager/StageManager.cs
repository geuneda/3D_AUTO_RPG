using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<GameObject> monsters = new List<GameObject>();

    void Start()
    {
        // 현재 씬에 있는 모든 몬스터를 초기 목록에 추가
        GameObject[] existingMonsters = GameObject.FindGameObjectsWithTag("Monster");
        monsters.AddRange(existingMonsters);
    }

    void Update()
    {
        // 몬스터 리스트에서 죽은 몬스터를 제거
        monsters.RemoveAll(monster => monster == null);

        // 만약 몬스터가 모두 제거되었다면 스테이지 클리어
        if (monsters.Count == 0)
        {
            StageCleared();
        }
    }

    public void RegisterMonster(GameObject monster)
    {
        if (!monsters.Contains(monster))
        {
            monsters.Add(monster);
        }
    }

    void StageCleared()
    {
        Debug.Log("Stage Cleared!");
        // TODO: 다음 스테이지로 이동하는 로직 추가
    }
}
