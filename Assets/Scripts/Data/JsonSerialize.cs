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

        // 완성된 json string 문자열을 8비트 부호없는 정수로 변환
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        // 변환된 바이트배열을 base-64 인코딩된 문자열로 변환
        string encodedJson = System.Convert.ToBase64String(bytes);

        // 변환된 값을 저장
        File.WriteAllText(fileName, encodedJson);
    }

    public static void LoadPlayerFromJson(Player player)
    {
        string fileName = Path.Combine(Application.persistentDataPath + "/PlayerData.json");

        if (File.Exists(fileName))
        {
            // json으로 저장된 문자열을 로드한다.
            string jsonFromFile = File.ReadAllText(fileName);

            // 읽어온 base-64 인코딩 문자열을 바이트배열로 변환
            byte[] bytes = System.Convert.FromBase64String(jsonFromFile);

            // 8비트 부호없는 정수를 json 문자열로 변환
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
