using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 표기법, 명명법(Naming Convention)
// 알아보기 쉬운 짧은 영단어들로 이름 짓기

// 1) 파스칼 케이스(PascalCase)
// 영어 단어를 적고 각 단어 첫 문자를 대문자로 적는다.
// C#. 함수명, 클래스명, public 멤버 변수.

// 2) 카멜 케이스(camelCase)
// 영어 단어를 적고 각 단어 첫 문자를 대문자로 적되,
// 맨 첫 글자는 소문자.
// C#. 지역 변수.
// private 멤버 변수 -> _camelCase

// (C# 구글 코딩 스타일)

public class CatController : MonoBehaviour
{
    [Header("----- 게임 매니저 -----")]
    public GameManager GameManager; // 게임 매니저 참조 변수

    [Header("----- 좌우 이동 -----")]
    public float MoveSpeed;     // 이동 속력(크기)
    public float XRange = 2.5f; // X 방향 범위

    [Header("----- 점프 -----")]
    public float JumpPower;     // 점프력

    Rigidbody2D _rigid;         // 리지드바디2D 컴포넌트 참조 변수
    Vector2 _velocity;          // 이동 속도(벡터)

    SpriteRenderer _renderer;   // 스프라이트렌더러 컴포넌트 참조 변수

    Animator _animator;         // 애니메이터 컴포넌트 참조 변수

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<T>() 함수
        // 현재 게임오브젝트에 붙어 있는 T 타입의 컴포넌트를 찾아서 반환
        // 만약, 없으면 null
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            bool isGround = false;  // 고양이 캐릭터가 바닥에 닿아 있는지 여부

            // _rigid.IsTouchingLayers() 함수는
            // 이 리지드바디가 무언가에 닿아 있으면 true,
            // 닿아 있지 않으면 false를 반환하는 함수
            isGround = _rigid.IsTouchingLayers();

            if (isGround)
            {
                Jump();
            }
        }

        //Debug.Log($"이번 프레임 계산 시간: {Time.deltaTime}");
    }

    // 유니티의 물리 엔진은 매 프레임마다 계산하지 않고
    // 별도 주기를 따라 계산한다.
    // 그 물리 엔진의 주기와 일치하는 것이 바로 FixedUpdate() 주기.
    // 고정된 시간 간격마다 호출되는 함수
    private void FixedUpdate()
    {
        //Debug.Log($"이번 고정 프레임 계산 시간: {Time.fixedDeltaTime}");
    }



    void Move()
    {
        _velocity = _rigid.velocity;
        _velocity.x = Input.GetAxis("Horizontal") * MoveSpeed;
        _rigid.velocity = _velocity;

        // 불가능
        // _rigid.velocity.x = Input.GetAxis("Horizontal") * MoveSpeed;
        // _rigid.velocity 자체가 어떤 구조체 값을 반환해 주는 것이기 때문에
        // 해당 값을 통째로 복사해서 수정한 뒤에 다시 적용해 줘야 한다.
        // (실제로 _rigid.velocity는 멤버 변수가 아니다.)


        // 고양이 캐릭터가 좌우 이동 한계가 있도록 설정해 주세요.
        Vector3 pos = transform.position;
        //if(pos.x > XRange)
        //{
        //    pos.x = XRange;
        //}
        //if(pos.x < -XRange)
        //{
        //    pos.x = -XRange;
        //}

        // Mathf
        // 유니티의 수학 관련 함수들이 모여 있는 구조체
        // 여러 static 함수들이 포함되어 있다.
        // MathF랑 헷갈리면 안 된다. Mathf로 사용.

        // Mathf.Clamp(value, min, max)
        // value를 min, max 사이 값으로 한정하여 반환해 준다.
        // 예를 들어, Mathf.Clamp(10.0f, -5.0f, 5.0f)이면 5.0f를 반환해 준다.
        pos.x = Mathf.Clamp(pos.x, -XRange, XRange);
        transform.position = pos;

        // 고양이가 좌우 실제 진행 방향을 바라보도록 하는 코드

        // 고양이가 오른쪽으로 움직이는 경우
        if (_velocity.x > 0.0f)
        {
            _renderer.flipX = false;
        }
        // 고양이가 왼쪽으로 움직이는 경우
        if (_velocity.x < 0.0f)
        {
            _renderer.flipX = true;
        }

        // 고양이 애니메이션 제어하는 코드
        // Mathf.Abs(value)
        // value의 절대값을 반환해 주는 함수
        // -3.0f -> 3.0f, 4.0f -> 4.0f
        float moveSpeed = Mathf.Abs(_velocity.x);
        // _animator의 패러미터(parameters) 중에서 한 float 변수를 찾아서
        // 그 값을 설정해 주는 함수
        _animator.SetFloat("MoveSpeed", moveSpeed);
    }


    // 점프를 실행하는 함수
    void Jump()
    {
        // _rigid.AddForce() 해당 리지드바디2D 객체에 힘을 가하는 함수

        //Vector2 upVector = new Vector2(0.0f, 1.0f);
        _rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        // 점프 애니메이션 재생
        _animator.SetTrigger("Jump");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            GameManager.AddHealth(-1);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Fish")
        {
            GameManager.AddHealth(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Water")
        {
            GameManager.EndGame();
        }
    }




    /*

    // 트리거 충돌이 발생했을 때 유니티에서 자동으로 호출하는 함수
    // 트리거 충돌의 발생 조건
    // 1. 어느 한쪽이 Rigidbody 컴포넌트를 가지고 있어야 한다.
    // 2. 양쪽 모두 Collider 컴포넌트가 있어야 한다.
    // 3. 어느 한쪽 Collider는 IsTrigger로 설정되어 있어야 한다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Flag")
        {
            Debug.Log("게임 클리어!");
            // 게임 클리어 처리
        }
    }

    // 콜리션(Collision) 충돌이 시작되는 순간 호출되는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"콜리션 충돌 시작: {collision.gameObject.name}");
    }

    // 콜리션(Collision) 충돌이 계속되는 동안 반복해서 호출되는 함수
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log($"콜리션 충돌 중: {collision.gameObject.name}");
    }

    // 콜리션(Collision) 충돌이 끝나는 순간 호출되는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log($"콜리션 충돌 종료: {collision.gameObject.name}");
    }

    */
}
