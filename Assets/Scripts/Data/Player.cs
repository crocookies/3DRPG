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
    }
}
