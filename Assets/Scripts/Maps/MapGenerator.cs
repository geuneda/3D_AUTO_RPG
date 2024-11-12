using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private int mapWidth = 20;
    [SerializeField] private int mapLength = 20;
    
    public Vector3 StartPoint { get; private set; }
    public Vector3 EndPoint { get; private set; }
    
    private void Start()
    {
        GenerateMap();
    }
    
    private void GenerateMap()
    {
        // 바닥 생성
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapLength; z++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                Instantiate(floorPrefab, pos, Quaternion.identity, transform);
            }
        }
        
        // 시작점과 끝점 설정
        StartPoint = new Vector3(1, 1, 1);
        EndPoint = new Vector3(mapWidth - 2, 1, mapLength - 2);
    }
} 