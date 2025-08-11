## 프로젝트 소개

Notion 링크 https://economic-kettle-c2e.notion.site/CatClimb-1d5c01e9d6ba8169a0fccc6a003fecfe?source=copy_link

게임 빌드 파일 링크 https://drive.google.com/file/d/1UILwgenifVZuz5t-MoQ3Ilhbu95Rnuon/view?usp=drive_link

게임 영상 유튜브 링크 https://youtube.com/shorts/UroTksfqBrw?feature=share

위에서 떨어지는 화살을 피하고 아래에서 차오르는 물로부터 도망치며 최대한 살아남아라!

유니티 입문 수업에서 제공된 코드를 참고하여 제작한 학습용 프로젝트로, 이전에 만든 CatGame의 로직을 확장하여 구현했습니다.

하늘에서 떨어지는 화살과 발판 위에 생성되는 생선은 프리팹(Prefab)을 활용해 동적으로 생성되며,
두 오브젝트 모두 Collider Trigger를 통해 충돌 시 체력이 감소하거나 증가하는 로직을 적용했습니다.

또한, 프리팹과 난수 생성을 이용해 무작위 위치에 구름 발판을 생성했고,
고양이가 점프할 때마다 이를 따라 움직이는 카메라 시스템을 구현했습니다.

화면 아래에서 차오르는 물에는 Collider를 부착하여, 고양이와 트리거 충돌 시 게임 오버 씬으로 전환되는 기능을 적용했습니다.

추가로, PlayerPrefs를 활용해 게임 오버 시 점수를 저장하고, 새 게임 시작 시 저장된 최고 점수와 이번 플레이 점수를 비교하여 최고 점수를 갱신하도록 하였습니다.

마지막으로, UI 버튼 기능을 이용해 데이터 초기화 버튼을 누르면 기록된 최고 점수가 초기화되도록 구현했습니다.
