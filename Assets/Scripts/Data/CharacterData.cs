using System.Collections.Generic;
using UnityEngine;

// 캐릭터 데이터 저장용 ScriptableObject
[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("기본 정보")]
    public string id;                // 플레이어 ID
    public int level;                // 레벨
    public int currentExp;           // 현재 경험치
    public int maxExp;               // 최대 경험치
    public int gold;                 // 골드
    [TextArea]
    public string description;       // 캐릭터 설명

    [Header("스탯")]
    public int baseAttack;           // 공격력
    public int baseDefense;          // 방어력
    public int critical;             // 크리티컬 확률
    public int hp;                   // 현재 체력
    public int maxHp;                // 최대 체력

    [Header("시작 아이템")]
    public List<Item> startingItems;  // 시작 아이템 리스트 (SO)
}
