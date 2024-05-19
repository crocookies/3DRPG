using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPos;

    public float curHP;
    public float maxHP;
    public float curMP;
    public float maxMP;
    public float curSP;
    public float maxSP;

    public float atk;
    public float mtk;
    public float def;
    public float mdf;

    public float minAtk;
    public float maxAtk;
    public float minMtk;
    public float maxMtk;

    public float[] lvHP = new float[20];
    public float[] lvMP = new float[20];
    public float[] lvSP = new float[20];

    public float[] lvAtk = new float[20];
    public float[] lvMtk = new float[20];
    public float[] lvDef = new float[20];
    public float[] lvMdf = new float[20];

    public int lv;
    public float exp;
    public float[] nextExp = new float[20];
    public int money;

    public int[] itemId = new int[5];
    public int[] itemCnt = new int[5];
    public string[] itemName = new string[5];
    public float[] itemRecoveryHP = new float[5];
    public float[] itemRecoveryMP = new float[5];
    public int[] itemPrice = new int[5];
    public Sprite[] itemIcon = new Sprite[5];

    public int[] quickSlotId = new int[4];
    public int[] quickSlotCnt = new int[4];
    public string[] quickSlotName = new string[4];
    public float[] quickSlotRecoveryHP = new float[4];
    public float[] quickSlotRecoveryMP = new float[4];
    public int[] quickSlotPrice = new int[4];
    public Sprite[] quickSlotIcon = new Sprite[4];

    public int[] slotId = new int[15];
    public int[] slotCnt = new int[15];
    public string[] slotName = new string[15];
    public float[] slotRecoveryHP = new float[15];
    public float[] slotRecoveryMP = new float[15];
    public int[] slotPrice = new int[15];
    public Sprite[] slotIcon = new Sprite[15];

    public int[] equipId = new int[5];
    public string[] equipType = new string[5];
    public string[] equipName = new string[5];
    public float[] equipAtk = new float[5];
    public float[] equipMtk = new float[5];
    public float[] equipDef = new float[5];
    public float[] equipMdf = new float[5];
    public float[] equipHP = new float[5];
    public float[] equipMP = new float[5];
    public int[] equipPrice = new int[5];
    public Sprite[] equipIcon = new Sprite[5];

    public int[] equipSlotId = new int[9];
    public string[] equipSlotType = new string[9];
    public string[] equipSlotName = new string[9];
    public float[] equipSlotAtk = new float[9];
    public float[] equipSlotMtk = new float[9];
    public float[] equipSlotDef = new float[9];
    public float[] equipSlotMdf = new float[9];
    public float[] equipSlotHP = new float[9];
    public float[] equipSlotMP = new float[9];
    public int[] equipSlotPrice = new int[9];
    public Sprite[] equipSlotIcon = new Sprite[9];

    public int equipedWeaponId;
    public string equipedWeaponType;
    public string equipedWeaponName;
    public float equipedWeaponAtk;
    public float equipedWeaponMtk;
    public float equipedWeaponDef;
    public float equipedWeaponMdf;
    public float equipedWeaponHP;
    public float equipedWeaponMP;
    public int equipedWeaponPrice;
    public Sprite equipedWeaponIcon;

    public int equipedClothesId;
    public string equipedClothesType;
    public string equipedClothesName;
    public float equipedClothesAtk;
    public float equipedClothesMtk;
    public float equipedClothesDef;
    public float equipedClothesMdf;
    public float equipedClothesHP;
    public float equipedClothesMP;
    public int equipedClothesPrice;
    public Sprite equipedClothesIcon;

    public int equipedAccessoriesId;
    public string equipedAccessoriesType;
    public string equipedAccessoriesName;
    public float equipedAccessoriesAtk;
    public float equipedAccessoriesMtk;
    public float equipedAccessoriesDef;
    public float equipedAccessoriesMdf;
    public float equipedAccessoriesHP;
    public float equipedAccessoriesMP;
    public int equipedAccessoriesPrice;
    public Sprite equipedAccessoriesIcon;

    public float BGMValue;
    public float SEValue;
    public bool fullScreen;

    public int[] questId = new int[3];
    public int[] questState = new int[3];
    public int[] questValue = new int[3];
    public int[] questCompleteValue = new int[3];
    public int[] questRewardMoney = new int[3];
    public float[] questRewardExp = new float[3];

    public PlayerData(Player player)
    {
        playerPos = player.playerPos;

        curHP = player.curHP;
        maxHP = player.maxHP;
        curMP = player.curMP;
        maxMP = player.maxMP;
        curSP = player.curSP;
        maxSP = player.maxSP;

        atk = player.atk;
        mtk = player.mtk;
        def = player.def;
        mdf = player.mdf;

        minAtk = player.minAtk;
        maxAtk = player.maxAtk;
        minMtk = player.minMtk;
        maxMtk = player.maxMtk;

        lvHP = player.lvHP;
        lvMP = player.lvMP;
        lvSP = player.lvSP;

        lvAtk = player.lvAtk;
        lvMtk = player.lvMtk;
        lvDef = player.lvDef;
        lvMdf = player.lvMdf;

        lv = player.lv;
        exp = player.exp;
        nextExp = player.nextExp;
        money = player.money;

        itemId = player.itemId;
        itemCnt = player.itemCnt;
        itemName = player.itemName;
        itemRecoveryHP = player.itemRecoveryHP;
        itemRecoveryMP = player.itemRecoveryMP;
        itemPrice = player.itemPrice;
        itemIcon = player.itemIcon;

        slotId = player.slotId;
        slotCnt = player.slotCnt;
        slotName = player.slotName;
        slotRecoveryHP = player.slotRecoveryHP;
        slotRecoveryMP = player.slotRecoveryMP;
        slotPrice = player.slotPrice;
        slotIcon = player.slotIcon;

        quickSlotId = player.quickSlotId;
        quickSlotCnt = player.quickSlotCnt;
        quickSlotName = player.quickSlotName;
        quickSlotRecoveryHP = player.quickSlotRecoveryHP;
        quickSlotRecoveryMP = player.quickSlotRecoveryMP;
        quickSlotPrice = player.quickSlotPrice;
        quickSlotIcon = player.quickSlotIcon;

        equipId = player.equipId;
        equipType = player.equipType;
        equipName = player.equipName;
        equipAtk = player.equipAtk;
        equipMtk = player.equipMtk;
        equipDef = player.equipDef;
        equipMdf = player.equipMdf;
        equipHP = player.equipHP;
        equipMP = player.equipMP;
        equipPrice = player.equipPrice;
        equipIcon = player.equipIcon;

        equipSlotId = player.equipSlotId;
        equipSlotType = player.equipSlotType;
        equipSlotName = player.equipSlotName;
        equipSlotAtk = player.equipSlotAtk;
        equipSlotMtk = player.equipSlotMtk;
        equipSlotDef = player.equipSlotDef;
        equipSlotMdf = player.equipSlotMdf;
        equipSlotHP = player.equipSlotHP;
        equipSlotMP = player.equipSlotMP;
        equipSlotPrice = player.equipSlotPrice;
        equipSlotIcon = player.equipSlotIcon;

        equipedWeaponId = player.equipedWeaponId;
        equipedWeaponType = player.equipedWeaponType;
        equipedWeaponName = player.equipedWeaponName;
        equipedWeaponAtk = player.equipedWeaponAtk;
        equipedWeaponMtk = player.equipedWeaponMtk;
        equipedWeaponDef = player.equipedWeaponDef;
        equipedWeaponMdf = player.equipedWeaponMdf;
        equipedWeaponHP = player.equipedWeaponHP;
        equipedWeaponMP = player.equipedWeaponMP;
        equipedWeaponPrice = player.equipedWeaponPrice;
        equipedWeaponIcon = player.equipedWeaponIcon;

        equipedClothesId = player.equipedClothesId;
        equipedClothesType = player.equipedClothesType;
        equipedClothesName = player.equipedClothesName;
        equipedClothesAtk = player.equipedClothesAtk;
        equipedClothesMtk = player.equipedClothesMtk;
        equipedClothesDef = player.equipedClothesDef;
        equipedClothesMdf = player.equipedClothesMdf;
        equipedClothesHP = player.equipedClothesHP;
        equipedClothesMP = player.equipedClothesMP;
        equipedClothesPrice = player.equipedClothesPrice;
        equipedClothesIcon = player.equipedClothesIcon;

        equipedAccessoriesId = player.equipedAccessoriesId;
        equipedAccessoriesType = player.equipedAccessoriesType;
        equipedAccessoriesName = player.equipedAccessoriesName;
        equipedAccessoriesAtk = player.equipedAccessoriesAtk;
        equipedAccessoriesMtk = player.equipedAccessoriesMtk;
        equipedAccessoriesDef = player.equipedAccessoriesDef;
        equipedAccessoriesMdf = player.equipedAccessoriesMdf;
        equipedAccessoriesHP = player.equipedAccessoriesHP;
        equipedAccessoriesMP = player.equipedAccessoriesMP;
        equipedAccessoriesPrice = player.equipedAccessoriesPrice;
        equipedAccessoriesIcon = player.equipedAccessoriesIcon;

        BGMValue = player.BGMValue;
        SEValue = player.SEValue;
        fullScreen = player.fullScreen;

        questId = player.questId;
        questState = player.questState;
        questValue = player.questValue;
        questCompleteValue = player.questCompleteValue;
        questRewardMoney = player.questRewardMoney;
        questRewardExp = player.questRewardExp;
}
}
