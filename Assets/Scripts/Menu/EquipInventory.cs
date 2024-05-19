using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInventory : MonoBehaviour
{
    public bool onSlot;
    public bool draging;

    public int slotNum;
    public int otherSlotNum;
    public string slotType;
    public string otherSlotType;

    [SerializeField]
    private Image dragIcon;

    Vector2 mousePos;

    public Slot[] slots;

    public static EquipInventory instance;

    void Awake()
    {
        EquipInventory.instance = this;
    }

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        DragItem();
    }

    public void SlotChange(int slotNum1, int slotNum2, string slotType1, string slotType2)
    {
        if (!onSlot)
            return;

        if (slotType1 == "슬롯" && slotType2 == "슬롯" && Player.instance.equipSlotId[slotNum1] > 0)
        {
            int tmpid = Player.instance.equipSlotId[slotNum1];
            Player.instance.equipSlotId[slotNum1] = Player.instance.equipSlotId[slotNum2];
            Player.instance.equipSlotId[slotNum2] = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum1];
            Player.instance.equipSlotType[slotNum1] = Player.instance.equipSlotType[slotNum2];
            Player.instance.equipSlotType[slotNum2] = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum1];
            Player.instance.equipSlotName[slotNum1] = Player.instance.equipSlotName[slotNum2];
            Player.instance.equipSlotName[slotNum2] = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum1];
            Player.instance.equipSlotAtk[slotNum1] = Player.instance.equipSlotAtk[slotNum2];
            Player.instance.equipSlotAtk[slotNum2] = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum1];
            Player.instance.equipSlotMtk[slotNum1] = Player.instance.equipSlotMtk[slotNum2];
            Player.instance.equipSlotMtk[slotNum2] = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum1];
            Player.instance.equipSlotDef[slotNum1] = Player.instance.equipSlotDef[slotNum2];
            Player.instance.equipSlotDef[slotNum2] = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum1];
            Player.instance.equipSlotMdf[slotNum1] = Player.instance.equipSlotMdf[slotNum2];
            Player.instance.equipSlotMdf[slotNum2] = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum1];
            Player.instance.equipSlotHP[slotNum1] = Player.instance.equipSlotHP[slotNum2];
            Player.instance.equipSlotHP[slotNum2] = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum1];
            Player.instance.equipSlotMP[slotNum1] = Player.instance.equipSlotMP[slotNum2];
            Player.instance.equipSlotMP[slotNum2] = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum1];
            Player.instance.equipSlotPrice[slotNum1] = Player.instance.equipSlotPrice[slotNum2];
            Player.instance.equipSlotPrice[slotNum2] = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum1];
            Player.instance.equipSlotIcon[slotNum1] = Player.instance.equipSlotIcon[slotNum2];
            Player.instance.equipSlotIcon[slotNum2] = tmpicon;
        }
        else if (slotType1 == "슬롯" && slotType2 == "무기" && Player.instance.equipSlotType[slotNum1] == "무기" && Player.instance.equipSlotId[slotNum1] > 0)
        {
            int tmpid = Player.instance.equipSlotId[slotNum1];
            Player.instance.equipSlotId[slotNum1] = Player.instance.equipedWeaponId;
            Player.instance.equipedWeaponId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum1];
            Player.instance.equipSlotType[slotNum1] = Player.instance.equipedWeaponType;
            Player.instance.equipedWeaponType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum1];
            Player.instance.equipSlotName[slotNum1] = Player.instance.equipedWeaponName;
            Player.instance.equipedWeaponName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum1];
            Player.instance.equipSlotAtk[slotNum1] = Player.instance.equipedWeaponAtk;
            Player.instance.equipedWeaponAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum1];
            Player.instance.equipSlotMtk[slotNum1] = Player.instance.equipedWeaponMtk;
            Player.instance.equipedWeaponMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum1];
            Player.instance.equipSlotDef[slotNum1] = Player.instance.equipedWeaponDef;
            Player.instance.equipedWeaponDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum1];
            Player.instance.equipSlotMdf[slotNum1] = Player.instance.equipedWeaponMdf;
            Player.instance.equipedWeaponMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum1];
            Player.instance.equipSlotHP[slotNum1] = Player.instance.equipedWeaponHP;
            Player.instance.equipedWeaponHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum1];
            Player.instance.equipSlotMP[slotNum1] = Player.instance.equipedWeaponMP;
            Player.instance.equipedWeaponMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum1];
            Player.instance.equipSlotPrice[slotNum1] = Player.instance.equipedWeaponPrice;
            Player.instance.equipedWeaponPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum1];
            Player.instance.equipSlotIcon[slotNum1] = Player.instance.equipedWeaponIcon;
            Player.instance.equipedWeaponIcon = tmpicon;
        }
        else if (slotType1 == "슬롯" && slotType2 == "의상" && Player.instance.equipSlotType[slotNum1] == "의상" && Player.instance.equipSlotId[slotNum1] > 0)
        {
            int tmpid = Player.instance.equipSlotId[slotNum1];
            Player.instance.equipSlotId[slotNum1] = Player.instance.equipedClothesId;
            Player.instance.equipedClothesId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum1];
            Player.instance.equipSlotType[slotNum1] = Player.instance.equipedClothesType;
            Player.instance.equipedClothesType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum1];
            Player.instance.equipSlotName[slotNum1] = Player.instance.equipedClothesName;
            Player.instance.equipedClothesName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum1];
            Player.instance.equipSlotAtk[slotNum1] = Player.instance.equipedClothesAtk;
            Player.instance.equipedClothesAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum1];
            Player.instance.equipSlotMtk[slotNum1] = Player.instance.equipedClothesMtk;
            Player.instance.equipedClothesMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum1];
            Player.instance.equipSlotDef[slotNum1] = Player.instance.equipedClothesDef;
            Player.instance.equipedClothesDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum1];
            Player.instance.equipSlotMdf[slotNum1] = Player.instance.equipedClothesMdf;
            Player.instance.equipedClothesMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum1];
            Player.instance.equipSlotHP[slotNum1] = Player.instance.equipedClothesHP;
            Player.instance.equipedClothesHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum1];
            Player.instance.equipSlotMP[slotNum1] = Player.instance.equipedClothesMP;
            Player.instance.equipedClothesMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum1];
            Player.instance.equipSlotPrice[slotNum1] = Player.instance.equipedClothesPrice;
            Player.instance.equipedClothesPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum1];
            Player.instance.equipSlotIcon[slotNum1] = Player.instance.equipedClothesIcon;
            Player.instance.equipedClothesIcon = tmpicon;
        }
        else if (slotType1 == "슬롯" && slotType2 == "장신구" && Player.instance.equipSlotType[slotNum1] == "장신구" && Player.instance.equipSlotId[slotNum1] > 0)
        {
            int tmpid = Player.instance.equipSlotId[slotNum1];
            Player.instance.equipSlotId[slotNum1] = Player.instance.equipedAccessoriesId;
            Player.instance.equipedAccessoriesId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum1];
            Player.instance.equipSlotType[slotNum1] = Player.instance.equipedAccessoriesType;
            Player.instance.equipedAccessoriesType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum1];
            Player.instance.equipSlotName[slotNum1] = Player.instance.equipedAccessoriesName;
            Player.instance.equipedAccessoriesName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum1];
            Player.instance.equipSlotAtk[slotNum1] = Player.instance.equipedAccessoriesAtk;
            Player.instance.equipedAccessoriesAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum1];
            Player.instance.equipSlotMtk[slotNum1] = Player.instance.equipedAccessoriesMtk;
            Player.instance.equipedAccessoriesMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum1];
            Player.instance.equipSlotDef[slotNum1] = Player.instance.equipedAccessoriesDef;
            Player.instance.equipedAccessoriesDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum1];
            Player.instance.equipSlotMdf[slotNum1] = Player.instance.equipedAccessoriesMdf;
            Player.instance.equipedAccessoriesMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum1];
            Player.instance.equipSlotHP[slotNum1] = Player.instance.equipedAccessoriesHP;
            Player.instance.equipedAccessoriesHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum1];
            Player.instance.equipSlotMP[slotNum1] = Player.instance.equipedAccessoriesMP;
            Player.instance.equipedAccessoriesMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum1];
            Player.instance.equipSlotPrice[slotNum1] = Player.instance.equipedAccessoriesPrice;
            Player.instance.equipedAccessoriesPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum1];
            Player.instance.equipSlotIcon[slotNum1] = Player.instance.equipedAccessoriesIcon;
            Player.instance.equipedAccessoriesIcon = tmpicon;
        }
        else if (slotType1 == "무기" && slotType2 == "슬롯" && Player.instance.equipedWeaponId > 0 && (Player.instance.equipSlotType[slotNum2] == "무기" || Player.instance.equipSlotId[slotNum2] == 0))
        {
            int tmpid = Player.instance.equipSlotId[slotNum2];
            Player.instance.equipSlotId[slotNum2] = Player.instance.equipedWeaponId;
            Player.instance.equipedWeaponId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum2];
            Player.instance.equipSlotType[slotNum2] = Player.instance.equipedWeaponType;
            Player.instance.equipedWeaponType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum2];
            Player.instance.equipSlotName[slotNum2] = Player.instance.equipedWeaponName;
            Player.instance.equipedWeaponName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum2];
            Player.instance.equipSlotAtk[slotNum2] = Player.instance.equipedWeaponAtk;
            Player.instance.equipedWeaponAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum2];
            Player.instance.equipSlotMtk[slotNum2] = Player.instance.equipedWeaponMtk;
            Player.instance.equipedWeaponMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum2];
            Player.instance.equipSlotDef[slotNum2] = Player.instance.equipedWeaponDef;
            Player.instance.equipedWeaponDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum2];
            Player.instance.equipSlotMdf[slotNum2] = Player.instance.equipedWeaponMdf;
            Player.instance.equipedWeaponMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum2];
            Player.instance.equipSlotHP[slotNum2] = Player.instance.equipedWeaponHP;
            Player.instance.equipedWeaponHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum2];
            Player.instance.equipSlotMP[slotNum2] = Player.instance.equipedWeaponMP;
            Player.instance.equipedWeaponMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum2];
            Player.instance.equipSlotPrice[slotNum2] = Player.instance.equipedWeaponPrice;
            Player.instance.equipedWeaponPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum2];
            Player.instance.equipSlotIcon[slotNum2] = Player.instance.equipedWeaponIcon;
            Player.instance.equipedWeaponIcon = tmpicon;
        }
        else if (slotType1 == "의상" && slotType2 == "슬롯" && Player.instance.equipedClothesId > 0 && (Player.instance.equipSlotType[slotNum2] == "의상" || Player.instance.equipSlotId[slotNum2] == 0))
        {
            int tmpid = Player.instance.equipSlotId[slotNum2];
            Player.instance.equipSlotId[slotNum2] = Player.instance.equipedClothesId;
            Player.instance.equipedClothesId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum2];
            Player.instance.equipSlotType[slotNum2] = Player.instance.equipedClothesType;
            Player.instance.equipedClothesType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum2];
            Player.instance.equipSlotName[slotNum2] = Player.instance.equipedClothesName;
            Player.instance.equipedClothesName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum2];
            Player.instance.equipSlotAtk[slotNum2] = Player.instance.equipedClothesAtk;
            Player.instance.equipedClothesAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum2];
            Player.instance.equipSlotMtk[slotNum2] = Player.instance.equipedClothesMtk;
            Player.instance.equipedClothesMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum2];
            Player.instance.equipSlotDef[slotNum2] = Player.instance.equipedClothesDef;
            Player.instance.equipedClothesDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum2];
            Player.instance.equipSlotMdf[slotNum2] = Player.instance.equipedClothesMdf;
            Player.instance.equipedClothesMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum2];
            Player.instance.equipSlotHP[slotNum2] = Player.instance.equipedClothesHP;
            Player.instance.equipedClothesHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum2];
            Player.instance.equipSlotMP[slotNum2] = Player.instance.equipedClothesMP;
            Player.instance.equipedClothesMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum2];
            Player.instance.equipSlotPrice[slotNum2] = Player.instance.equipedClothesPrice;
            Player.instance.equipedClothesPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum2];
            Player.instance.equipSlotIcon[slotNum2] = Player.instance.equipedClothesIcon;
            Player.instance.equipedClothesIcon = tmpicon;
        }
        else if (slotType1 == "장신구" && slotType2 == "슬롯" && Player.instance.equipedAccessoriesId > 0 && (Player.instance.equipSlotType[slotNum2] == "장신구" || Player.instance.equipSlotId[slotNum2] == 0))
        {
            int tmpid = Player.instance.equipSlotId[slotNum2];
            Player.instance.equipSlotId[slotNum2] = Player.instance.equipedAccessoriesId;
            Player.instance.equipedAccessoriesId = tmpid;

            string tmptype = Player.instance.equipSlotType[slotNum2];
            Player.instance.equipSlotType[slotNum2] = Player.instance.equipedAccessoriesType;
            Player.instance.equipedAccessoriesType = tmptype;

            string tmpname = Player.instance.equipSlotName[slotNum2];
            Player.instance.equipSlotName[slotNum2] = Player.instance.equipedAccessoriesName;
            Player.instance.equipedAccessoriesName = tmpname;

            float tmpatk = Player.instance.equipSlotAtk[slotNum2];
            Player.instance.equipSlotAtk[slotNum2] = Player.instance.equipedAccessoriesAtk;
            Player.instance.equipedAccessoriesAtk = tmpatk;

            float tmpmtk = Player.instance.equipSlotMtk[slotNum2];
            Player.instance.equipSlotMtk[slotNum2] = Player.instance.equipedAccessoriesMtk;
            Player.instance.equipedAccessoriesMtk = tmpmtk;

            float tmpdef = Player.instance.equipSlotDef[slotNum2];
            Player.instance.equipSlotDef[slotNum2] = Player.instance.equipedAccessoriesDef;
            Player.instance.equipedAccessoriesDef = tmpdef;

            float tmpmdf = Player.instance.equipSlotMdf[slotNum2];
            Player.instance.equipSlotMdf[slotNum2] = Player.instance.equipedAccessoriesMdf;
            Player.instance.equipedAccessoriesMdf = tmpmdf;

            float tmphp = Player.instance.equipSlotHP[slotNum2];
            Player.instance.equipSlotHP[slotNum2] = Player.instance.equipedAccessoriesHP;
            Player.instance.equipedAccessoriesHP = tmphp;

            float tmpmp = Player.instance.equipSlotMP[slotNum2];
            Player.instance.equipSlotMP[slotNum2] = Player.instance.equipedAccessoriesMP;
            Player.instance.equipedAccessoriesMP = tmpmp;

            int tmpprice = Player.instance.equipSlotPrice[slotNum2];
            Player.instance.equipSlotPrice[slotNum2] = Player.instance.equipedAccessoriesPrice;
            Player.instance.equipedAccessoriesPrice = tmpprice;

            Sprite tmpicon = Player.instance.equipSlotIcon[slotNum2];
            Player.instance.equipSlotIcon[slotNum2] = Player.instance.equipedAccessoriesIcon;
            Player.instance.equipedAccessoriesIcon = tmpicon;
        }

        slotNum = otherSlotNum;
        slotType = otherSlotType;
    }
    
    public void DragItem()
    {
        mousePos = Input.mousePosition;
        dragIcon.rectTransform.position = mousePos;
        
        if (draging)
        {
            if (slotType == "슬롯" && Player.instance.equipSlotId[slotNum] > 0 && !dragIcon.enabled)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.equipSlotIcon[slotNum];
            }
            else if (slotType == "무기" && Player.instance.equipedWeaponId > 0 && !dragIcon.enabled)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.equipedWeaponIcon;
            }
            else if (slotType == "의상" && Player.instance.equipedClothesId > 0 && !dragIcon.enabled)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.equipedClothesIcon;
            }
            else if (slotType == "장신구" && Player.instance.equipedAccessoriesId > 0 && !dragIcon.enabled)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.equipedAccessoriesIcon;
            }
        }
        else
        {
            if (dragIcon.enabled)
                dragIcon.enabled = false;
        }
    }
}
