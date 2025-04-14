using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveSpawner : MonoBehaviour
{
    // CloudWave의 프리팹
    public GameObject CloudWavePrefab;

    public float SpawnSpan;     // 생성 시간 간격
    public float InitialHeight;     // 처음 생성할 높이
    public float HeightIncrement;   // 생성할 높이 간격

    float _spawnTimer = 0.0f;      // 생성할 시간을 재는 타이머
    int _spawnCount = 0;        // 생성된 구름 웨이브(CouldWave) 수

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnCloudWave();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer < 0.0f)
        {
            _spawnTimer = SpawnSpan;
            SpawnCloudWave();
        }
    }

    // 구름 웨이브(CloudWave)를 생성하는 함수
    void SpawnCloudWave()
    {
        GameObject cloudWave = Instantiate(CloudWavePrefab);
        cloudWave.transform.position =
            new Vector3(0.0f, InitialHeight + _spawnCount * HeightIncrement, 0.0f);
        _spawnCount++;
    }
}
