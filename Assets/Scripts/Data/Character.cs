using System;
using System.Collections.Generic;

/// <summary>
/// 캐릭터 정보 및 아이템 장착에 따른 스탯 관리 클래스
/// </summary>
public class Character
{
    // 상태 변경 이벤트 (UI에서 구독 가능)
    public event Action OnStatusChanged;

    // 캐릭터 기본 정보
    public string Id { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int Experience { get; private set; }

    // 기본 스탯 (장비 없이)
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }
    public int BaseCritical { get; private set; }
    public int MaxHP { get; private set; }

    public int HP { get; private set; }          // 현재 체력
    public int Attack { get; private set; }      // 최종 공격력
    public int Defense { get; private set; }     // 최종 방어력
    public int Critical { get; private set; }    // 최종 치명타
    public int TotalHP { get; private set; }     // 장비 포함 총 HP

    // 인벤토리와 장착 아이템 목록
    private List<Item> inventory = new();
    private List<Item> equippedItems = new();

    // 외부에서 읽기만 가능하도록 제공
    public IReadOnlyList<Item> Inventory => inventory.AsReadOnly();
    public IReadOnlyList<Item> EquippedItems => equippedItems.AsReadOnly();

    /// <summary>
    /// 생성자 - 기본 스탯 및 정보 설정
    /// </summary>
    public Character(string id, int level, int gold, int exp, int baseAtk, int baseDef, int baseCrit, int maxHP)
    {
        Id = id;
        Level = level;
        Gold = gold;
        Experience = exp;

        BaseAttack = baseAtk;
        BaseDefense = baseDef;
        BaseCritical = baseCrit;
        MaxHP = maxHP;
        HP = MaxHP;

        CalculateStats();
    }

    /// <summary>
    /// 아이템을 인벤토리에 추가
    /// </summary>
    public void AddItem(Item item)
    {
        if (!inventory.Contains(item))
        {
            inventory.Add(item);
            OnStatusChanged?.Invoke(); // UI 갱신 등
        }
    }

    /// <summary>
    /// 아이템 장착
    /// </summary>
    public void Equip(Item item)
    {
        if (!inventory.Contains(item)) return; // 인벤토리에 없는 아이템은 장착 불가

        // 동일 슬롯의 기존 아이템이 있으면 해제
        Item currentlyEquipped = GetEquippedItem(item.slot);
        if (currentlyEquipped != null)
            UnEquip(currentlyEquipped);

        equippedItems.Add(item); // 장착
        CalculateStats();
        OnStatusChanged?.Invoke();
    }

    /// <summary>
    /// 아이템 장착 해제
    /// </summary>
    public void UnEquip(Item item)
    {
        if (equippedItems.Remove(item))
        {
            CalculateStats();
            OnStatusChanged?.Invoke();
        }
    }

    /// <summary>
    /// 해당 슬롯에 장착된 아이템 반환
    /// </summary>
    public Item GetEquippedItem(ItemSlot slot)
    {
        foreach (var item in equippedItems)
        {
            if (item.slot == slot)
                return item;
        }
        return null;
    }

    /// <summary>
    /// 해당 아이템이 장착되어 있는지 확인
    /// </summary>
    public bool IsEquipped(Item item) => equippedItems.Contains(item);

    /// <summary>
    /// 장착 아이템의 스탯을 포함해 최종 스탯 재계산
    /// </summary>
    private void CalculateStats()
    {
        int atk = BaseAttack;
        int def = BaseDefense;
        int crit = BaseCritical;
        int hp = MaxHP;

        foreach (var item in equippedItems)
        {
            atk += item.attackBonus;
            def += item.defenseBonus;
            crit += item.criticalBonus;
            hp += item.hpBonus;
        }

        Attack = atk;
        Defense = def;
        Critical = crit;
        TotalHP = hp;

        // 현재 HP가 초과하지 않도록 보정
        if (HP > TotalHP)
            HP = TotalHP;
    }
}
