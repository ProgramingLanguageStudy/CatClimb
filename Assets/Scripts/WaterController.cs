using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물(Water) 게임오브젝트가 일정한 속력으로 위로 상승해서
// 고양이를 추격해 오게 하는 클래스
public class WaterController : MonoBehaviour
{
    public float Speed;     // 물 게임오브젝트가 상승하는 속력

    // Update is called once per frame
    void Update()
    {
        // 1
        transform.Translate(0.0f, Speed * Time.deltaTime, 0.0f);

        // 2
        // Vector3.right (1.0f, 0.0f, 0.0f)
        // Vector3.up    (0.0f, 1.0f, 0.0f)
        // vector3.forward (0.0f, 0.0f, 1.0f)
        //transform.Translate(Vector3.up * Speed * Time.deltaTime);

        // 3
        //Vector3 pos = transform.position;
        //pos.y += Speed * Time.deltaTime;
        //transform.position = pos;
    }
}
