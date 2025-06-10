using UnityEngine;

// 게임 전반을 관리하는 매니저 클래스
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("ScriptableObject 데이터")]
    public CharacterData playerData;        // 플레이어 기본 정보 ScriptableObject

    [Header("UI 연결")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private UIPlayerInfo playerInfoUI;

    public Character Player { get; private set; }

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitializePlayer();
        InitializeUI();
    }

    // 플레이어 인스턴스 초기화
    private void InitializePlayer()
    {
        // ScriptableObject 캐릭터 데이터로부터 런타임 캐릭터 객체 생성
        Player = new Character(
        playerData.id,
        playerData.level,
        playerData.gold,          // SO에 골드가 있다고 가정
        playerData.currentExp,    // 경험치
        playerData.baseAttack,
        playerData.baseDefense,
        playerData.critical,
        playerData.maxHp          // HP는 MaxHP로 초기화됨
        );


        // 시작 아이템 추가
        foreach (var item in playerData.startingItems)
        {
            Player.AddItem(item);
        }
    }

    // UI 초기화 및 기본 화면 세팅
    private void InitializeUI()
    {
        // 좌측 플레이어 정보 UI 업데이트
        playerInfoUI.SetPlayerInfo(playerData);

        // 메인 메뉴 오픈 및 캐릭터 정보 세팅
        uiManager.OpenMainMenu();
        uiManager.statusUI.SetCharacter(Player);
        uiManager.inventoryUI.InitInventory(Player);
    }
}
