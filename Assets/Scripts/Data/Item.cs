using UnityEngine;

/// <summary>
/// 아이템 데이터 ScriptableObject 정의
/// </summary>
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;                      // 아이템 고유 ID
    public string itemName;             // 아이템 이름
    [TextArea]
    public string description;          // 아이템 설명
    public Sprite icon;                 // 아이템 아이콘 (UI에 사용)

    // 스탯 보너스
    public int attackBonus;            // 공격력 보너스
    public int defenseBonus;           // 방어력 보너스
    public int criticalBonus;          // 치명타 확률 보너스
    public int hpBonus;                // HP 보너스

    public ItemSlot slot;              // 장착 위치 (무기, 방어구 등)
}
