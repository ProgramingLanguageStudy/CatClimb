using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearScene : MonoBehaviour
{
    [Tooltip("최고기록을 표시할 텍스트 컴포넌트")]
    public Text BestHeightText;

    [Tooltip("이번 판 기록을 표시할 텍스트 컴포넌트")]
    public Text HeightText;

    [Tooltip("게임 재시작 버튼(배경 버튼) 컴포넌트")]
    public Button ReplayButton;

    [Tooltip("데이터 초기화 버튼 컴포넌트")]
    public Button ResetButton;


    // Start is called before the first frame update
    void Start()
    {
        // 버튼이 클릭되었을 때
        // "LoadPlayScene()"이라는 함수가 실행되도록 하는 코드
        ReplayButton.onClick.AddListener(LoadPlayScene);
        ResetButton.onClick.AddListener(ClearSaveData);

        BestHeightText.text = "최고기록: " +
            PlayerData.BestHeightRecord.ToString("F2");

        HeightText.text = "이번기록: " +
            PlayerData.HeightRecord.ToString("F2");
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Play");
    }

    void ClearSaveData()
    {
        // PlayerPrefs로 저장한 모든 데이터를 삭제하는 코드
        PlayerPrefs.DeleteAll();

        // "BestHeight" 이름으로 저장한 데이터 하나만 삭제하는 코드
        //PlayerPrefs.DeleteKey("BestHeight");
    }
}
