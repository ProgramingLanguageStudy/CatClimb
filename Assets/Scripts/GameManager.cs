using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("----- 주인공 캐릭터 -----")]
    public GameObject Cat;

    [Header("----- 스탯 -----")]
    public int MaxHealth = 3;

    [Header("----- UI -----")]
    public GameObject[] HealthImages;
    public Text HeightText;
    public Text BestHeightText;

    int _health = 0;    // 현재 체력
    float _height = 0.0f;   // 현재 이번 판의 최고 높이
    float _bestHeight = 0.0f;   // 역대 최고 높이


    // Start is called before the first frame update
    void Start()
    {
        _health = MaxHealth;
        UpdateHealthImages();

        UpdateHeightText();

        // 저장된 데이터를 불러오는 코드
        _bestHeight = PlayerPrefs.GetFloat("BestHeight", 0.0f);
        UpdateBestHeightText();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateHeight();
    }

    // 현재 체력을 변화시키는 함수
    public void AddHealth(int amount)
    {
        _health = _health + amount;
        if(_health > MaxHealth)
        {
            _health = MaxHealth;
        }
        if(_health < 0)
        {
            _health = 0;
        }

        //_health = Mathf.Clamp(_health + amount, 0, MaxHealth);

        if(_health <= 0)
        {
            // 게임 오버
            EndGame();
        }

        UpdateHealthImages();
    }

    // 이번 판의 최고 높이를 계산하는 함수
    void CalculateHeight()
    {
        if(Cat.transform.position.y > _height)
        {
            _height = Cat.transform.position.y;
            // UI 표시
            UpdateHeightText();
        }

        if(_bestHeight < _height)
        {
            _bestHeight = _height;
            UpdateBestHeightText();

            // "BestHeight"라는 이름으로 역대 최고 기록을 저장
            PlayerPrefs.SetFloat("BestHeight", _bestHeight);
            PlayerPrefs.Save();
        }
    }

    // 체력 UI 표시 함수
    void UpdateHealthImages()
    {
        // 헬스(하트) 게임오브젝트들을 전부 Off
        for(int i = 0; i < HealthImages.Length; i++)
        {
            HealthImages[i].SetActive(false);
        }

        // 현재 체력(_health)만큼 헬스(하트) 게임오브젝트들을 On
        for(int i = 0; i < _health; i++)
        {
            HealthImages[i].SetActive(true);
        }
    }

    // 이번 판 최고 높이 UI 표시 함수
    void UpdateHeightText()
    {
        // 어떤 float 변수 뒤에 .ToString("F2")을 하게 되면
        // 소수점 둘째 자리까지만 표시되는 문자열로 변환이 된다.
        HeightText.text = "높이: " + _height.ToString("F2");
    }

    // 역대 최고 높이 UI 표시 함수
    void UpdateBestHeightText()
    {
        BestHeightText.text = "최고기록: " + _bestHeight.ToString("F2");
    }

    public void EndGame()
    {
        Debug.Log("게임 오버!");

        PlayerData.HeightRecord = _height;
        PlayerData.BestHeightRecord = _bestHeight;

        // 현재 씬을 끝내고 "Clear" 이름을 가진 씬을 로드
        SceneManager.LoadScene("Clear");

        // Time.timeScale은 유니티의 시간 배속
        // 기본값은 1.0f으로 되어 있고 이것은 현실 시간 배속
        // 0.0f으로 하면 유니티의 시간이 멈추게 됩니다.
        //Time.timeScale = 0.0f;
    }
}
