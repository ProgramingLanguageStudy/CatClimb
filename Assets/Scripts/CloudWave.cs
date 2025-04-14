using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 씬에 생성될 때
// 자식 오브젝트로 갖고 있는 구름 게임오브젝트 5개 중 일부를
// 랜덤하게 끄는 역할
public class CloudWave : MonoBehaviour
{
    public GameObject[] Clouds;
    public GameObject FishPrefab;

    public int MaxRemovalNum = 2;   // 최대로 지울 구름 개수
    public float FishRate = 0.1f;   // 물고기 생성될 확률 (10% 확률)
    public float FishOffsetY;       // 생성된 물고기가 구름 위로 얼마나 높이 떠 있는지 변수

    // Start is called before the first frame update
    void Start()
    {
        ShuffleClouds();

        int removalNum = Random.Range(0, MaxRemovalNum + 1);
        for(int i = 0; i < Clouds.Length; i++)
        {
            // 현재 방문한 구름 번호가
            // 지워줘야 하는 구름 개수보다 작으면
            // 해당 구름 게임오브젝트를 비활성화
            if(i < removalNum)
            {
                Clouds[i].SetActive(false);
            }
            else
            {
                // N% 확률로 어떤 일이 벌어지게 하고 싶은 경우
                // 0.0f~1.0f 랜덤한 float 값 생성
                // 그 랜덤한 float 값이 확률보다 작은 경우 해당 사건이 벌어지게 작업
                float randomValue = Random.Range(0.0f, 1.0f);
                //float randomValue = Random.value;
                // Random.value는 0.0f~1.0f 사이 랜덤한 float 값을 되돌려 준다.
                if(randomValue < FishRate)
                {
                    // 물고기 게임오브젝트를 프리팹에서 복제해서 씬에 생성
                    GameObject fish = Instantiate(FishPrefab);
                    // pos라는 이름으로 물고기 위치로 사용할 Vector3 변수 선언
                    Vector3 pos = fish.transform.position;
                    // pos를 현재 구름 게임오브젝트의 위치와 동일하게 설정
                    pos = Clouds[i].transform.position;
                    // pos.y(높이)를 FishOffsetY만큼 위로 설정
                    pos.y = pos.y + FishOffsetY;    // pos.y += FishOffsetY;
                    // 실제 물고기 게임오브젝트 위치에 pos 값을 설정
                    fish.transform.position = pos;
                }
            }

            
        }
    }

    // Clouds 배열의 순서를 랜덤하게 셔플하는 함수
    void ShuffleClouds()
    {
        for(int i = 0; i < Clouds.Length; i++)
        {
            int ranIndex = Random.Range(0, Clouds.Length);
            GameObject temp = Clouds[i];
            Clouds[i] = Clouds[ranIndex];
            Clouds[ranIndex] = temp;
        }
    }
}
