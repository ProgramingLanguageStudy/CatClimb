using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. Cat 게임오브젝트의 Transform 컴포넌트에 접근한다.
// 2. 매 프레임 Cat의 Transform의 높이를 따라 자신의 Transform 높이를 조절한다.

public class CameraController : MonoBehaviour
{
    public GameObject Cat;
    // Update is called once per frame
    void Update()
    {
        Vector3 catPos = Cat.transform.position;
        Vector3 pos = transform.position;
        pos.y = catPos.y;
        transform.position = pos;
    }
}
