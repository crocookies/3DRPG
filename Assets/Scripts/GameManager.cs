using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool paused;
    public bool shop;
    public bool equipShop;
    public bool talkEvent;

    private AudioSource audioSource;

    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        LoadGame();
    }

    private void Update()
    {
        UseQuickSlot();
        SoundSetting();
    }

    public void SoundSetting()
    {
        audioSource.volume = Player.instance.BGMValue;
    }

    public void SaveGame()
    {
        JsonSerialize.SavePlayerToJson(Player.instance);
        Application.Quit();
    }

    public void LoadGame()
    {
        JsonSerialize.LoadPlayerFromJson(Player.instance);
    }

    public void OpenShop()
    {
        shop = true;
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shop = false;
        Time.timeScale = 1;
    }

    public void OpenEquipShop()
    {
        equipShop = true;
        Time.timeScale = 0;
    }

    public void CloseEquipShop()
    {
        equipShop = false;
        Time.timeScale = 1;
    }

    public void StartTalking()
    {
        talkEvent = true;
        Time.timeScale = 0;
    }

    public void EndTalking()
    {
        talkEvent = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
    }

    public void CursorOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CursorOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddItem(int id, int cnt)
    {
        for (int index = 0; index < Player.instance.quickSlotId.Length; index++)
        {
            if (Player.instance.quickSlotId[index] == id)
            {
                Player.instance.quickSlotCnt[index] += cnt;
                return;
            }
        }

        for (int index = 0; index < Player.instance.slotId.Length; index++)
        {
            if (Player.instance.slotId[index] == id)
            {
                Player.instance.slotCnt[index] += cnt;
                return;
            }
        }

        for (int index = 0; index < Player.instance.slotId.Length; index++)
        {
            if (Player.instance.slotId[index] == 0)
            {
                AddSlot(id, index, cnt);
                return;
            }
        }

        Debug.Log("������ �����մϴ�");
    }

    void AddSlot(int id, int slotNum, int cnt)
    {
        Player.instance.slotId[slotNum] = Player.instance.itemId[id];
        Player.instance.slotCnt[slotNum] += cnt;
        Player.instance.slotName[slotNum] = Player.instance.itemName[id];
        Player.instance.slotRecoveryHP[slotNum] = Player.instance.itemRecoveryHP[id];
        Player.instance.slotRecoveryMP[slotNum] = Player.instance.itemRecoveryMP[id];
        Player.instance.slotPrice[slotNum] = Player.instance.itemPrice[id];
        Player.instance.slotIcon[slotNum] = Player.instance.itemIcon[id];
    }

    public void AddEquip(int id)
    {
        for (int index = 0; index < Player.instance.equipSlotId.Length; index++)
        {
            if (Player.instance.equipSlotId[index] == 0)
            {
                Player.instance.equipSlotId[index] = Player.instance.equipId[id];
                Player.instance.equipSlotType[index] = Player.instance.equipType[id];
                Player.instance.equipSlotName[index] = Player.instance.equipName[id];
                Player.instance.equipSlotAtk[index] = Player.instance.equipAtk[id];
                Player.instance.equipSlotMtk[index] = Player.instance.equipMtk[id];
                Player.instance.equipSlotDef[index] = Player.instance.equipDef[id];
                Player.instance.equipSlotMdf[index] = Player.instance.equipMdf[id];
                Player.instance.equipSlotHP[index] = Player.instance.equipHP[id];
                Player.instance.equipSlotMP[index] = Player.instance.equipMP[id];
                Player.instance.equipSlotPrice[index] = Player.instance.equipPrice[id];
                Player.instance.equipSlotIcon[index] = Player.instance.equipIcon[id];

                return;
            }
        }

        Debug.Log("��� ������ �����մϴ�");
    }

    public void MonsterRezen(GameObject monster, Vector3 pos, float time)
    {
        StartCoroutine(Rezen(monster, pos, time));
    }

    private IEnumerator Rezen(GameObject monster, Vector3 pos, float time)
    {
        monster.gameObject.SetActive(false);

        yield return new WaitForSeconds(time);

        monster.gameObject.SetActive(true);
        monster.gameObject.transform.position = pos;

        yield return null;
    }

    private void UseQuickSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Player.instance.quickSlotCnt[0] > 0)
        {
            SoundEffect.instance.Item();
            Player.instance.quickSlotCnt[0]--;
            Player.instance.curHP += Player.instance.quickSlotRecoveryHP[0];
            Player.instance.curMP += Player.instance.quickSlotRecoveryMP[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Player.instance.quickSlotCnt[1] > 0)
        {
            SoundEffect.instance.Item();
            Player.instance.quickSlotCnt[1]--;
            Player.instance.curHP += Player.instance.quickSlotRecoveryHP[1];
            Player.instance.curMP += Player.instance.quickSlotRecoveryMP[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && Player.instance.quickSlotCnt[2] > 0)
        {
            SoundEffect.instance.Item();
            Player.instance.quickSlotCnt[2]--;
            Player.instance.curHP += Player.instance.quickSlotRecoveryHP[2];
            Player.instance.curMP += Player.instance.quickSlotRecoveryMP[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && Player.instance.quickSlotCnt[3] > 0)
        {
            SoundEffect.instance.Item();
            Player.instance.quickSlotCnt[3]--;
            Player.instance.curHP += Player.instance.quickSlotRecoveryHP[3];
            Player.instance.curMP += Player.instance.quickSlotRecoveryMP[3];
        }
    }
}
