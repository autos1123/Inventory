using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 상태창 UI - 캐릭터 상태, 뒤로가기 버튼
public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI strText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI critText;

    private Character character;

    private void Start()
    {
        backButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }

    // 캐릭터 상태 텍스트 업데이트
    public void SetCharacter(Character c)
    {
        character = c;
        character.OnStatusChanged += UpdateUI; // 이벤트 구독
        UpdateUI(); // 초기 출력
    }

    private void UpdateUI()
    {
        strText.text = $"공격력\n {character.Attack}";
        defText.text = $"방어력\n {character.Defense}";
        hpText.text = $"체력\n {character.HP} / {character.TotalHP}";
        critText.text = $"치명타\n {character.Critical}";
    }

}
