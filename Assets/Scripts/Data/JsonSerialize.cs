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
        }
    }
}
