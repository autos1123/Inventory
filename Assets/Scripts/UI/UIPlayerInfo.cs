using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 좌측 상단 고정 UI: 플레이어 아이디, 레벨, 경험치, 설명, 경험치 바 표시
public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;

    // 플레이어 데이터로 UI 업데이트
    public void SetPlayerInfo(CharacterData characterData)
    {
        idText.text = $"{characterData.id}";
        levelText.text = $"Lv {characterData.level}";
        descriptionText.text = characterData.description;
        goldText.text = $"Gold: {characterData.gold}";

        expSlider.maxValue = characterData.maxExp;
        expSlider.value = characterData.currentExp;

        expText.text = $"{characterData.currentExp} / {characterData.maxExp}";
    }
}
