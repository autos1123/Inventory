using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 인벤토리 슬롯 UI - 아이템 아이콘, 이름, 장착/해제 버튼, 장착 상태 테두리
public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Button equipButton;

    [SerializeField] private Outline selectionOutline;  // 장착 시 테두리 표시용 (Outline 컴포넌트)

    private Item item;
    private Character player;
    private UIInventory inventoryUI;

    private void Start()
    {
        equipButton.onClick.AddListener(OnEquipButtonClicked);
    }

    // 슬롯에 아이템과 플레이어 세팅, UI 갱신
    public void SetItem(Item newItem, Character character, UIInventory ui)
    {
        item = newItem;
        player = character;
        inventoryUI = ui;

        iconImage.sprite = item.icon;
        itemNameText.text = item.itemName;

        RefreshUI();
    }

    // 장착 상태에 따라 버튼 텍스트 및 테두리 갱신
    public void RefreshUI()
    {
        bool isEquipped = player.GetEquippedItem(item.slot) == item;

        // 테두리 표시: 장착 시 활성화, 해제 시 비활성화
        if (selectionOutline != null)
            selectionOutline.enabled = isEquipped;
    }

    // 버튼 클릭 시 장착/해제 토글 처리
    private void OnEquipButtonClicked()
    {
        if (player.GetEquippedItem(item.slot) == item)
        {
            player.UnEquip(item);
        }
        else
        {
            player.Equip(item);
        }

        inventoryUI.RefreshAllSlots(); // 전체 슬롯 상태 갱신
    }
}
