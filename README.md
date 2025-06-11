# 🧙‍♂️ Unity RPG 인벤토리 & 장착 시스템

Unity에서 RPG 스타일의 게임을 개발할 때 기본이 되는 **인벤토리 시스템**을 구현한 프로젝트입니다.  
ScriptableObject 기반의 아이템 데이터 구조, 장비 장착/해제 기능, UI 연동까지 포함되어 있어  
소규모 RPG나 로그라이크 게임의 기반으로 활용하기 좋습니다.


---

## 📌 주요 기능 요약

- ✅ **ScriptableObject**로 아이템 정의 및 관리
- 🧍 **Character 클래스**: 장비 장착 시 실시간 스탯 반영
- 🧳 **인벤토리 UI**: ScrollView 기반 아이템 리스트
- 🎯 **장착 여부에 따른 하이라이팅 (Outline)**
- ⚙️ **이벤트 기반 UI 자동 갱신**

---

## 🏗️ 프로젝트 구조

```yaml
Assets/
│
├── Scripts/
│ ├── Item.cs # 아이템 데이터 (ScriptableObject)
│ ├── Character.cs # 캐릭터 정보 및 장착 로직
│ ├── UIInventory.cs # 인벤토리 패널 컨트롤러
│ ├── UISlot.cs # 개별 슬롯 UI
│ └── UIStatusPanel.cs # 캐릭터 스탯 표시 UI
│
├── Prefabs/
│ └── Slot.prefab # UISlot에 사용될 프리팹
│
├── ScriptableObjects/
│ └── 다양한 아이템 .asset 파일
```

---

## 🧾 사용 방법

### 1. 아이템 생성하기 (ScriptableObject)

- `Assets > Create > Inventory > Item` 메뉴를 통해 새 아이템 생성
- 아이콘, 이름, 스탯, 장착 슬롯 등을 자유롭게 설정

### 2. 시작 아이템 등록

- `GameManager` 또는 캐릭터 생성 로직에서 `StartItems` 리스트에 아이템 등록
- 예시:
```csharp
foreach (var item in startItems)
{
    player.AddItem(item);
}
```
### 3. 인벤토리 UI 연결
UIInventory 오브젝트에 slotPrefab, slotParent, backButton 할당

UISlot 프리팹에는 아이콘 이미지, 이름 텍스트, 버튼, Outline 컴포넌트 포함

### 4. 스탯 UI 연결
UIStatusPanel의 SetCharacter(character) 호출로 캐릭터 연동

캐릭터의 OnStatusChanged 이벤트를 통해 실시간 반영됨

## 📐 UI 예시
인벤토리: ScrollView + GridLayoutGroup

Spacing, Padding 조절로 정렬

슬롯: 아이콘 + 이름 + "장착/해제" 버튼 + 테두리(Outline)

<!-- 예시 이미지 사용 시 -->

## ⚔️ 장비 시스템 특징
동일한 슬롯에 이미 장착 중인 아이템이 있으면 자동 해제 후 새 장착

장착 시:

공격력, 방어력, 체력, 치명타 수치가 즉시 반영

장착 아이템은 따로 리스트에서 관리됨 (equippedItems)

Outline.enabled = true 를 통해 UI에 시각적으로 반영

## 🧠 팁 & 트러블슈팅
문제	해결 방법
슬롯은 생기는데 아이템이 없음	ScriptableObject를 StartItems에 등록했는지 확인
장착해도 스탯이 안 바뀜	OnStatusChanged 이벤트가 UI에 연결되었는지 확인
테두리가 안 보임	UISlot 프리팹에 Outline 컴포넌트가 연결되었는지 확인

## 🛠️ 확장 아이디어
### 🔄 장비 아이템에 내구도 추가

### 🧩 장비 강화 시스템

### 🗂️ 인벤토리 정렬/필터 기능

### 🎨 아이템 등급(색상) 표시

### 🧪 저장/불러오기 기능 (JSON, Binary 등)
