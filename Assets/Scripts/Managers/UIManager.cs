using UnityEngine;

// UIManager는 메인메뉴, 상태, 인벤토리 UI를 제어한다
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("각 UI 컴포넌트 연결")]
    public UIMainMenu mainMenuUI;
    public UIStatus statusUI;
    public UIInventory inventoryUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // 메인 메뉴 열기
    public void OpenMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(false);
    }

    // 상태창 열기
    public void OpenStatus()
    {
        mainMenuUI.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(false);
    }

    // 인벤토리 열기
    public void OpenInventory()
    {
        mainMenuUI.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(true);
    }
}
