using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Equiped : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private int slotNum;

    private float lastClick;

    private bool doubleClick;

    public Sprite empty;

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        slotNum = transform.GetSiblingIndex();
    }

    void Update()
    {
        switch (slotNum)
        {
            case 0:
                if (Player.instance.equipedWeaponId <= 0)
                    image.sprite = empty;
                else
                    image.sprite = Player.instance.equipedWeaponIcon;
                break;
            case 1:
                if (Player.instance.equipedClothesId <= 0)
                    image.sprite = empty;
                else
                    image.sprite = Player.instance.equipedClothesIcon;
                break;
            case 2:
                if (Player.instance.equipedAccessoriesId <= 0)
                    image.sprite = empty;
                else
                    image.sprite = Player.instance.equipedAccessoriesIcon;
                break;
        }
    }

    private void LateUpdate()
    {
        lastClick += Time.unscaledDeltaTime;

        if (lastClick > 0.5f)
            doubleClick = false;
    }

    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작
    {
        EquipInventory.instance.draging = true;
    }

    public void OnDrag(PointerEventData eventData) // 드래그 중
    {

    }

    public void OnEndDrag(PointerEventData eventData) // 드래그 끝
    {
        EquipInventory.instance.draging = false;
        EquipInventory.instance.SlotChange(EquipInventory.instance.slotNum, EquipInventory.instance.otherSlotNum, EquipInventory.instance.slotType, EquipInventory.instance.otherSlotType);
    }

    public void OnPointerClick(PointerEventData eventData) // 클릭
    {
        lastClick = 0;

        Unequip();
    }

    public void OnPointerEnter(PointerEventData eventData) // 커서 올림
    {
        EquipInventory.instance.onSlot = true;

        if (!EquipInventory.instance.draging)
        {
            switch (slotNum)
            {
                case 0:
                    EquipInventory.instance.slotType = "무기";
                    break;
                case 1:
                    EquipInventory.instance.slotType = "의상";
                    break;
                case 2:
                    EquipInventory.instance.slotType = "장신구";
                    break;
            }
        }
        else
        {
            switch (slotNum)
            {
                case 0:
                    EquipInventory.instance.otherSlotType = "무기";
                    break;
                case 1:
                    EquipInventory.instance.otherSlotType = "의상";
                    break;
                case 2:
                    EquipInventory.instance.otherSlotType = "장신구";
                    break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData) // 커서 내림
    {
        EquipInventory.instance.onSlot = false;
    }

    private void Unequip()
    {
        if (doubleClick)
        {
            doubleClick = false;
            SoundEffect.instance.Item();

            switch (slotNum)
            {
                case 0:
                    GameManager.Instance.AddEquip(Player.instance.equipedWeaponId);
                    UnequipedWeapon();
                    break;
                case 1:
                    GameManager.Instance.AddEquip(Player.instance.equipedClothesId);
                    UnequipedClothes();
                    break;
                case 2:
                    GameManager.Instance.AddEquip(Player.instance.equipedAccessoriesId);
                    UnequipedAccessories();
                    break;
            }

            
        }
        else
        {
            doubleClick = true;
        }
    }

    private void UnequipedWeapon()
    {
        Player.instance.equipedWeaponId = 0;
        Player.instance.equipedWeaponType = "";
        Player.instance.equipedWeaponName = "";
        Player.instance.equipedWeaponAtk = 0;
        Player.instance.equipedWeaponMtk = 0;
        Player.instance.equipedWeaponDef = 0;
        Player.instance.equipedWeaponMdf = 0;
        Player.instance.equipedWeaponHP = 0;
        Player.instance.equipedWeaponMP = 0;
        Player.instance.equipedWeaponPrice = 0;
        Player.instance.equipedWeaponIcon = empty;
    }

    private void UnequipedClothes()
    {
        Player.instance.equipedClothesId = 0;
        Player.instance.equipedClothesType = "";
        Player.instance.equipedClothesName = "";
        Player.instance.equipedClothesAtk = 0;
        Player.instance.equipedClothesMtk = 0;
        Player.instance.equipedClothesDef = 0;
        Player.instance.equipedClothesMdf = 0;
        Player.instance.equipedClothesHP = 0;
        Player.instance.equipedClothesMP = 0;
        Player.instance.equipedClothesPrice = 0;
        Player.instance.equipedClothesIcon = empty;
    }

    private void UnequipedAccessories()
    {
        Player.instance.equipedAccessoriesId = 0;
        Player.instance.equipedAccessoriesType = "";
        Player.instance.equipedAccessoriesName = "";
        Player.instance.equipedAccessoriesAtk = 0;
        Player.instance.equipedAccessoriesMtk = 0;
        Player.instance.equipedAccessoriesDef = 0;
        Player.instance.equipedAccessoriesMdf = 0;
        Player.instance.equipedAccessoriesHP = 0;
        Player.instance.equipedAccessoriesMP = 0;
        Player.instance.equipedAccessoriesPrice = 0;
        Player.instance.equipedAccessoriesIcon = empty;
    }
}
