using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 메인 메뉴 UI: Status, Inventory 버튼과 캐릭터 기본 정보 표시 (오른쪽 영역)
public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(() => UIManager.Instance.OpenStatus());
        inventoryButton.onClick.AddListener(() => UIManager.Instance.OpenInventory());
    }

    
}
