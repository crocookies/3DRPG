using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool paused;
    public bool inven;
    public bool shop;

    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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

        Debug.Log("슬롯이 부족합니다");
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
