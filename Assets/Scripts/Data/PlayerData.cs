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

    public int[] slotId = new int[18];
    public int[] slotCnt = new int[18];
    public string[] slotName = new string[18];
    public float[] slotRecoveryHP = new float[18];
    public float[] slotRecoveryMP = new float[18];
    public int[] slotPrice = new int[18];
    public Sprite[] slotIcon = new Sprite[18];

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
    }
}
