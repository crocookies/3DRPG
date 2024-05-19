using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.LowLevel;

public class EquipSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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
        if (Player.instance.equipSlotId[slotNum] > 0)
            image.sprite = Player.instance.equipSlotIcon[slotNum];
        else
            image.sprite = empty;
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

        Equip();
    }

    public void OnPointerEnter(PointerEventData eventData) // 커서 올림
    {
        EquipInventory.instance.onSlot = true;

        if (!EquipInventory.instance.draging)
        {
            EquipInventory.instance.slotType = "슬롯";
            EquipInventory.instance.slotNum = slotNum;
        }
        else
        {
            EquipInventory.instance.otherSlotType = "슬롯";
            EquipInventory.instance.otherSlotNum = slotNum;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // 커서 내림
    {
        EquipInventory.instance.onSlot = false;
    }

    private void Equip()
    {
        if (doubleClick && Player.instance.equipSlotId[slotNum] > 0)
        {
            doubleClick = false;
            SoundEffect.instance.Equip();
            
            switch (Player.instance.equipSlotType[slotNum])
            {
                case "무기":
                    WeaponEquip();
                    break;
                case "의상":
                    ClothesEquip();
                    break;
                case "장신구":
                    AccessoriesEquip();
                    break;
            }
        }
        else
        {
            doubleClick = true;
        }
    }

    private void WeaponEquip()
    {
        int tmpid = Player.instance.equipSlotId[slotNum];
        Player.instance.equipSlotId[slotNum] = Player.instance.equipedWeaponId;
        Player.instance.equipedWeaponId = tmpid;

        string tmptype = Player.instance.equipSlotType[slotNum];
        Player.instance.equipSlotType[slotNum] = Player.instance.equipedWeaponType;
        Player.instance.equipedWeaponType = tmptype;

        string tmpname = Player.instance.equipSlotName[slotNum];
        Player.instance.equipSlotName[slotNum] = Player.instance.equipedWeaponName;
        Player.instance.equipedWeaponName = tmpname;

        float tmpatk = Player.instance.equipSlotAtk[slotNum];
        Player.instance.equipSlotAtk[slotNum] = Player.instance.equipedWeaponAtk;
        Player.instance.equipedWeaponAtk = tmpatk;

        float tmpmtk = Player.instance.equipSlotMtk[slotNum];
        Player.instance.equipSlotMtk[slotNum] = Player.instance.equipedWeaponMtk;
        Player.instance.equipedWeaponMtk = tmpmtk;

        float tmpdef = Player.instance.equipSlotDef[slotNum];
        Player.instance.equipSlotDef[slotNum] = Player.instance.equipedWeaponDef;
        Player.instance.equipedWeaponDef = tmpdef;

        float tmpmdf = Player.instance.equipSlotMdf[slotNum];
        Player.instance.equipSlotMdf[slotNum] = Player.instance.equipedWeaponMdf;
        Player.instance.equipedWeaponMdf = tmpmdf;

        float tmphp = Player.instance.equipSlotHP[slotNum];
        Player.instance.equipSlotHP[slotNum] = Player.instance.equipedWeaponHP;
        Player.instance.equipedWeaponHP = tmphp;

        float tmpmp = Player.instance.equipSlotMP[slotNum];
        Player.instance.equipSlotMP[slotNum] = Player.instance.equipedWeaponMP;
        Player.instance.equipedWeaponMP = tmpmp;

        int tmpprice = Player.instance.equipSlotPrice[slotNum];
        Player.instance.equipSlotPrice[slotNum] = Player.instance.equipedWeaponPrice;
        Player.instance.equipedWeaponPrice = tmpprice;

        Sprite tmpicon = Player.instance.equipSlotIcon[slotNum];
        Player.instance.equipSlotIcon[slotNum] = Player.instance.equipedWeaponIcon;
        Player.instance.equipedWeaponIcon = tmpicon;
    }

    private void ClothesEquip()
    {
        int tmpid = Player.instance.equipSlotId[slotNum];
        Player.instance.equipSlotId[slotNum] = Player.instance.equipedClothesId;
        Player.instance.equipedClothesId = tmpid;

        string tmptype = Player.instance.equipSlotType[slotNum];
        Player.instance.equipSlotType[slotNum] = Player.instance.equipedClothesType;
        Player.instance.equipedClothesType = tmptype;

        string tmpname = Player.instance.equipSlotName[slotNum];
        Player.instance.equipSlotName[slotNum] = Player.instance.equipedClothesName;
        Player.instance.equipedClothesName = tmpname;

        float tmpatk = Player.instance.equipSlotAtk[slotNum];
        Player.instance.equipSlotAtk[slotNum] = Player.instance.equipedClothesAtk;
        Player.instance.equipedClothesAtk = tmpatk;

        float tmpmtk = Player.instance.equipSlotMtk[slotNum];
        Player.instance.equipSlotMtk[slotNum] = Player.instance.equipedClothesMtk;
        Player.instance.equipedClothesMtk = tmpmtk;

        float tmpdef = Player.instance.equipSlotDef[slotNum];
        Player.instance.equipSlotDef[slotNum] = Player.instance.equipedClothesDef;
        Player.instance.equipedClothesDef = tmpdef;

        float tmpmdf = Player.instance.equipSlotMdf[slotNum];
        Player.instance.equipSlotMdf[slotNum] = Player.instance.equipedClothesMdf;
        Player.instance.equipedClothesMdf = tmpmdf;

        float tmphp = Player.instance.equipSlotHP[slotNum];
        Player.instance.equipSlotHP[slotNum] = Player.instance.equipedClothesHP;
        Player.instance.equipedClothesHP = tmphp;

        float tmpmp = Player.instance.equipSlotMP[slotNum];
        Player.instance.equipSlotMP[slotNum] = Player.instance.equipedClothesMP;
        Player.instance.equipedClothesMP = tmpmp;

        int tmpprice = Player.instance.equipSlotPrice[slotNum];
        Player.instance.equipSlotPrice[slotNum] = Player.instance.equipedClothesPrice;
        Player.instance.equipedClothesPrice = tmpprice;

        Sprite tmpicon = Player.instance.equipSlotIcon[slotNum];
        Player.instance.equipSlotIcon[slotNum] = Player.instance.equipedClothesIcon;
        Player.instance.equipedClothesIcon = tmpicon;
    }

    private void AccessoriesEquip()
    {
        int tmpid = Player.instance.equipSlotId[slotNum];
        Player.instance.equipSlotId[slotNum] = Player.instance.equipedAccessoriesId;
        Player.instance.equipedAccessoriesId = tmpid;

        string tmptype = Player.instance.equipSlotType[slotNum];
        Player.instance.equipSlotType[slotNum] = Player.instance.equipedAccessoriesType;
        Player.instance.equipedAccessoriesType = tmptype;

        string tmpname = Player.instance.equipSlotName[slotNum];
        Player.instance.equipSlotName[slotNum] = Player.instance.equipedAccessoriesName;
        Player.instance.equipedAccessoriesName = tmpname;

        float tmpatk = Player.instance.equipSlotAtk[slotNum];
        Player.instance.equipSlotAtk[slotNum] = Player.instance.equipedAccessoriesAtk;
        Player.instance.equipedAccessoriesAtk = tmpatk;

        float tmpmtk = Player.instance.equipSlotMtk[slotNum];
        Player.instance.equipSlotMtk[slotNum] = Player.instance.equipedAccessoriesMtk;
        Player.instance.equipedAccessoriesMtk = tmpmtk;

        float tmpdef = Player.instance.equipSlotDef[slotNum];
        Player.instance.equipSlotDef[slotNum] = Player.instance.equipedAccessoriesDef;
        Player.instance.equipedAccessoriesDef = tmpdef;

        float tmpmdf = Player.instance.equipSlotMdf[slotNum];
        Player.instance.equipSlotMdf[slotNum] = Player.instance.equipedAccessoriesMdf;
        Player.instance.equipedAccessoriesMdf = tmpmdf;

        float tmphp = Player.instance.equipSlotHP[slotNum];
        Player.instance.equipSlotHP[slotNum] = Player.instance.equipedAccessoriesHP;
        Player.instance.equipedAccessoriesHP = tmphp;

        float tmpmp = Player.instance.equipSlotMP[slotNum];
        Player.instance.equipSlotMP[slotNum] = Player.instance.equipedAccessoriesMP;
        Player.instance.equipedAccessoriesMP = tmpmp;

        int tmpprice = Player.instance.equipSlotPrice[slotNum];
        Player.instance.equipSlotPrice[slotNum] = Player.instance.equipedAccessoriesPrice;
        Player.instance.equipedAccessoriesPrice = tmpprice;

        Sprite tmpicon = Player.instance.equipSlotIcon[slotNum];
        Player.instance.equipSlotIcon[slotNum] = Player.instance.equipedAccessoriesIcon;
        Player.instance.equipedAccessoriesIcon = tmpicon;
    }
}
