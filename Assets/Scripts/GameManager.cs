using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool paused;
    public bool inven;
    public bool shop;

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
        LoadGame();
    }

    public void SaveGame()
    {
        JsonSerialize.SavePlayerToJson(Player.instance);
    }

    public void LoadGame()
    {
        JsonSerialize.LoadPlayerFromJson(Player.instance);
    }

    public void OpenInventory()
    {
        inven = true;
        Time.timeScale = 0;
    }
    
    public void CloseInventory()
    {
        inven = false;
        Time.timeScale = 1;
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
}
