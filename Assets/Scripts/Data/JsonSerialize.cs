using System.IO;
using UnityEngine;

public class JsonSerialize
{
    public static void SavePlayerToJson(Player player)
    {
        string fileName = Path.Combine(Application.persistentDataPath + "/PlayerData.json");

        if (File.Exists(fileName))
            File.Delete(fileName);

        PlayerData data = new PlayerData(player);
        string json = JsonUtility.ToJson(data);

        // �ϼ��� json string ���ڿ��� 8��Ʈ ��ȣ���� ������ ��ȯ
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        // ��ȯ�� ����Ʈ�迭�� base-64 ���ڵ��� ���ڿ��� ��ȯ
        string encodedJson = System.Convert.ToBase64String(bytes);

        // ��ȯ�� ���� ����
        File.WriteAllText(fileName, encodedJson);
    }

    public static void LoadPlayerFromJson(Player player)
    {
        string fileName = Path.Combine(Application.persistentDataPath + "/PlayerData.json");

        if (File.Exists(fileName))
        {
            // json���� ����� ���ڿ��� �ε��Ѵ�.
            string jsonFromFile = File.ReadAllText(fileName);

            // �о�� base-64 ���ڵ� ���ڿ��� ����Ʈ�迭�� ��ȯ
            byte[] bytes = System.Convert.FromBase64String(jsonFromFile);

            // 8��Ʈ ��ȣ���� ������ json ���ڿ��� ��ȯ
            string decodedJson = System.Text.Encoding.UTF8.GetString(bytes);

            PlayerData data = JsonUtility.FromJson<PlayerData>(decodedJson);

            player.playerPos = data.playerPos;

            player.curHP = data.curHP;
            player.maxHP = data.maxHP;
            player.curMP = data.curMP;
            player.maxMP = data.maxMP;
            player.curSP = data.curSP;
            player.maxSP = data.maxSP;

            player.atk = data.atk;
            player.mtk = data.mtk;
            player.def = data.def;
            player.mdf = data.mdf;

            player.lvHP = data.lvHP;
            player.lvMP = data.lvMP;
            player.lvSP = data.lvSP;

            player.lvAtk = data.lvAtk;
            player.lvMtk = data.lvMtk;
            player.lvDef = data.lvDef;
            player.lvMdf = data.lvMdf;

            player.lv = data.lv;
            player.exp = data.exp;
            player.nextExp = data.nextExp;
            player.money = data.money;
            player.itemCnt = data.itemCnt;

            player.itemId = data.itemId;
            player.itemCnt = data.itemCnt;
            player.itemName = data.itemName;
            player.itemRecoveryHP = data.itemRecoveryHP;
            player.itemRecoveryMP = data.itemRecoveryMP;
            player.itemPrice = data.itemPrice;
            player.itemIcon = data.itemIcon;

            player.slotId = data.slotId;
            player.slotCnt = data.slotCnt;
            player.slotName = data.slotName;
            player.slotRecoveryHP = data.slotRecoveryHP;
            player.slotRecoveryMP = data.slotRecoveryMP;
            player.slotPrice = data.slotPrice;
            player.slotIcon = data.slotIcon;

            player.quickSlotId = data.quickSlotId;
            player.quickSlotCnt = data.quickSlotCnt;
            player.quickSlotName = data.quickSlotName;
            player.quickSlotRecoveryHP = data.quickSlotRecoveryHP;
            player.quickSlotRecoveryMP = data.quickSlotRecoveryMP;
            player.quickSlotPrice = data.quickSlotPrice;
            player.quickSlotIcon = data.quickSlotIcon;

            player.equipId = data.equipId;
            player.equipType = data.equipType;
            player.equipName = data.equipName;
            player.equipAtk = data.equipAtk;
            player.equipMtk = data.equipMtk;
            player.equipDef = data.equipDef;
            player.equipMdf = data.equipMdf;
            player.equipHP = data.equipHP;
            player.equipMP = data.equipMP;
            player.equipPrice = data.equipPrice;
            player.equipIcon = data.equipIcon;

            player.equipSlotId = data.equipSlotId;
            player.equipSlotType = data.equipSlotType;
            player.equipSlotName = data.equipSlotName;
            player.equipSlotAtk = data.equipSlotAtk;
            player.equipSlotMtk = data.equipSlotMtk;
            player.equipSlotDef = data.equipSlotDef;
            player.equipSlotMdf = data.equipSlotMdf;
            player.equipSlotHP = data.equipSlotHP;
            player.equipSlotMP = data.equipSlotMP;
            player.equipSlotPrice = data.equipSlotPrice;
            player.equipSlotIcon = data.equipSlotIcon;

            player.equipedWeaponId = data.equipedWeaponId;
            player.equipedWeaponType = data.equipedWeaponType;
            player.equipedWeaponName = data.equipedWeaponName;
            player.equipedWeaponAtk = data.equipedWeaponAtk;
            player.equipedWeaponMtk = data.equipedWeaponMtk;
            player.equipedWeaponDef = data.equipedWeaponDef;
            player.equipedWeaponMdf = data.equipedWeaponMdf;
            player.equipedWeaponHP = data.equipedWeaponHP;
            player.equipedWeaponMP = data.equipedWeaponMP;
            player.equipedWeaponPrice = data.equipedWeaponPrice;
            player.equipedWeaponIcon = data.equipedWeaponIcon;

            player.equipedClothesId = data.equipedClothesId;
            player.equipedClothesType = data.equipedClothesType;
            player.equipedClothesName = data.equipedClothesName;
            player.equipedClothesAtk = data.equipedClothesAtk;
            player.equipedClothesMtk = data.equipedClothesMtk;
            player.equipedClothesDef = data.equipedClothesDef;
            player.equipedClothesMdf = data.equipedClothesMdf;
            player.equipedClothesHP = data.equipedClothesHP;
            player.equipedClothesMP = data.equipedClothesMP;
            player.equipedClothesPrice = data.equipedClothesPrice;
            player.equipedClothesIcon = data.equipedClothesIcon;

            player.equipedAccessoriesId = data.equipedAccessoriesId;
            player.equipedAccessoriesType = data.equipedAccessoriesType;
            player.equipedAccessoriesName = data.equipedAccessoriesName;
            player.equipedAccessoriesAtk = data.equipedAccessoriesAtk;
            player.equipedAccessoriesMtk = data.equipedAccessoriesMtk;
            player.equipedAccessoriesDef = data.equipedAccessoriesDef;
            player.equipedAccessoriesMdf = data.equipedAccessoriesMdf;
            player.equipedAccessoriesHP = data.equipedAccessoriesHP;
            player.equipedAccessoriesMP = data.equipedAccessoriesMP;
            player.equipedAccessoriesPrice = data.equipedAccessoriesPrice;
            player.equipedAccessoriesIcon = data.equipedAccessoriesIcon;

            player.BGMValue = data.BGMValue;
            player.SEValue = data.SEValue;
            player.fullScreen = data.fullScreen;

            player.questId = data.questId;
            player.questState = data.questState;
            player.questValue = data.questValue;
            player.questCompleteValue = data.questCompleteValue;
            player.questRewardMoney = data.questRewardMoney;
            player.questRewardExp = data.questRewardExp;
        }
    }
}
