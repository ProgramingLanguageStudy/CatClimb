using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Arrow 게임오브젝트를 일정 시간 간격마다
// 씬에 생성하는 클래스

public class ArrowSpawner : MonoBehaviour
{
    [Tooltip("화살표 게임오브젝트의 원본 프리팹")]
    public GameObject ArrowPrefab;

    [Tooltip("고양이 캐릭터 게임오브젝트")]
    public GameObject Cat;

    [Tooltip("고양이로부터 얼마나 높은 곳에서 화살표 게임오브젝트를 생성할지 결정하는 변수")]
    public float SpawnOffsetY;

    [Tooltip("화살표 게임오브젝트를 생성할 x좌표 기준점 배열")]
    public GameObject[] SpawnPoints;

    [Tooltip("화살표 게임오브젝트 생성 간격 시간(초)")]
    public float SpawnSpan;

    float _spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTimer = SpawnSpan;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer < 0.0f)
        {
            _spawnTimer = SpawnSpan;
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        // 1. 화살표(Arrow) 게임오브젝트를 프리팹에서 복제하여 생성한다.
        // 2. 화살표(Arrow) 게임오브젝트가 생성되는 위치의 y좌표는
        // 고양이(Cat) 게임오브젝트보다 일정 높이만큼 높은 곳으로 설정한다.
        // 3. 화살표(Arrow) 게임오브젝트가 생성되는 위치의 x좌표는
        // 정해져 있는 지점들 중 랜덤한 하나를 골라서 그것의 x좌표로 설정한다.

        GameObject arrow = Instantiate(ArrowPrefab);

        Vector3 pos = arrow.transform.position;
        pos.y = Cat.transform.position.y + SpawnOffsetY;

        int ranIndex = Random.Range(0, SpawnPoints.Length);
        GameObject spawnPoint = SpawnPoints[ranIndex];
        pos.x = spawnPoint.transform.position.x;

        arrow.transform.position = pos;
    }
}
