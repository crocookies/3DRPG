using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    public float[] lvHP;
    public float[] lvMP;
    public float[] lvSP;

    public float[] lvAtk;
    public float[] lvMtk;
    public float[] lvDef;
    public float[] lvMdf;

    public int lv;
    public float exp;
    public float[] nextExp;
    public int money;

    public int[] itemId;
    public int[] itemCnt;
    public string[] itemName;
    public float[] itemRecoveryHP;
    public float[] itemRecoveryMP;
    public int[] itemPrice;
    public Sprite[] itemIcon;

    public int[] slotId;
    public int[] slotCnt;
    public string[] slotName;
    public float[] slotRecoveryHP;
    public float[] slotRecoveryMP;
    public int[] slotPrice;
    public Sprite[] slotIcon;

    public int[] quickSlotId;
    public int[] quickSlotCnt;
    public string[] quickSlotName;
    public float[] quickSlotRecoveryHP;
    public float[] quickSlotRecoveryMP;
    public int[] quickSlotPrice;
    public Sprite[] quickSlotIcon;

    public int[] equipId;
    public string[] equipType;
    public string[] equipName;
    public float[] equipAtk;
    public float[] equipMtk;
    public float[] equipDef;
    public float[] equipMdf;
    public float[] equipHP; 
    public float[] equipMP; 
    public int[] equipPrice;
    public Sprite[] equipIcon;

    public int[] equipSlotId;
    public string[] equipSlotType;
    public string[] equipSlotName;
    public float[] equipSlotAtk;
    public float[] equipSlotMtk;
    public float[] equipSlotDef;
    public float[] equipSlotMdf;
    public float[] equipSlotHP;
    public float[] equipSlotMP;
    public int[] equipSlotPrice;
    public Sprite[] equipSlotIcon;

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

    public int[] questId;
    public int[] questState;
    public int[] questValue;
    public int[] questCompleteValue;
    public int[] questRewardMoney;
    public float[] questRewardExp;

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (curHP > maxHP)
            curHP = maxHP;

        if (curMP > maxMP)
            curMP = maxMP;

        if (curSP > maxSP)
            curSP = maxSP;

        if (lv < 19)
        {
            if (exp >= nextExp[lv])
            {
                exp -= nextExp[lv];
                lv++;
            }
        }

        maxHP = lvHP[lv];
        maxMP = lvMP[lv];
        maxSP = lvSP[lv];

        atk = lvAtk[lv];
        mtk = lvMtk[lv];
        def = lvDef[lv];
        mdf = lvMdf[lv];

        if (fullScreen)
            Screen.SetResolution(1920, 1080, true);
        else
            Screen.SetResolution(1280, 720, false);
    }
}
