using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 인벤토리 UI - 아이템 목록, 장착/해제 기능, 뒤로가기 버튼
public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Transform slotParent;       // 슬롯 부모 (스크롤뷰 Content)
    [SerializeField] private GameObject slotPrefab;       // 슬롯 프리팹
    [SerializeField] private UIStatus statusPanel;
    private List<UISlot> slots = new List<UISlot>();
    private Character player;

    private void Start()
    {
        backButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }

    // 인벤토리 UI 초기화
    public void InitInventory(Character character)
    {
        player = character;

        // 기존 슬롯 삭제
        foreach (var slot in slots)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();

        // 인벤토리에 있는 아이템만큼 슬롯 생성
        foreach (var item in player.Inventory)
        {
            var slotObj = Instantiate(slotPrefab, slotParent);
            var slot = slotObj.GetComponent<UISlot>();
            slot.SetItem(item, player, this); // UIInventory 자기 자신 넘겨줌
            slots.Add(slot);
        }
        statusPanel.SetCharacter(character);
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slots)
        {
            slot.RefreshUI(); // 각 슬롯의 테두리 및 상태 갱신
        }
    }
}
