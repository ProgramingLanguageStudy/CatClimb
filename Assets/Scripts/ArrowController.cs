using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [Tooltip("이 게임오브젝트가 아래로 이동하는 속력")]
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
