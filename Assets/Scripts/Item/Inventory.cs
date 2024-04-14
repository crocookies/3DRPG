using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool onSlot;
    public bool draging;

    public int slotNum;
    public int otherSlotNum;

    public Image dragIcon;

    Vector2 mousePos;

    public Slot[] slots;

    public static Inventory instance;

    void Awake()
    {
        Inventory.instance = this;
    }

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        //DebugTest();
    }

    private void LateUpdate()
    {
        DragItem();
    }
    /*
    void DebugTest()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Instance.AddItem(1, 1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameManager.Instance.AddItem(2, 1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            GameManager.Instance.AddItem(3, 1);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            GameManager.Instance.AddItem(4, 1);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            GameManager.Instance.AddItem(1, -1);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            GameManager.Instance.AddItem(2, -1);

        if (Input.GetKeyDown(KeyCode.Alpha7))
            GameManager.Instance.AddItem(3, -1);

        if (Input.GetKeyDown(KeyCode.Alpha8))
            GameManager.Instance.AddItem(4, -1);
    }
    */

    public void SlotChange(int slotNum1, int slotNum2)
    {
        if (!onSlot || Player.instance.slotId[slotNum1] <= 0)
        {
            slotNum = otherSlotNum;
            return;
        }

        int tmpid = Player.instance.slotId[slotNum1];
        Player.instance.slotId[slotNum1] = Player.instance.slotId[slotNum2];
        Player.instance.slotId[slotNum2] = tmpid;

        int tmpcnt = Player.instance.slotCnt[slotNum1];
        Player.instance.slotCnt[slotNum1] = Player.instance.slotCnt[slotNum2];
        Player.instance.slotCnt[slotNum2] = tmpcnt;

        string tmpname = Player.instance.slotName[slotNum1];
        Player.instance.slotName[slotNum1] = Player.instance.slotName[slotNum2];
        Player.instance.slotName[slotNum2] = tmpname;

        float tmprecoveryhp = Player.instance.slotRecoveryHP[slotNum1];
        Player.instance.slotRecoveryHP[slotNum1] = Player.instance.slotRecoveryHP[slotNum2];
        Player.instance.slotRecoveryHP[slotNum2] = tmprecoveryhp;

        float tmprecoverymp = Player.instance.slotRecoveryMP[slotNum1];
        Player.instance.slotRecoveryMP[slotNum1] = Player.instance.slotRecoveryMP[slotNum2];
        Player.instance.slotRecoveryMP[slotNum2] = tmprecoverymp;

        Sprite tmpicon = Player.instance.slotIcon[slotNum1];
        Player.instance.slotIcon[slotNum1] = Player.instance.slotIcon[slotNum2];
        Player.instance.slotIcon[slotNum2] = tmpicon;

        slotNum = otherSlotNum;
    }
    
    public void DragItem()
    {
        mousePos = Input.mousePosition;
        dragIcon.rectTransform.position = mousePos;
        
        if (draging && Player.instance.slotId[slotNum] > 0)
        {
            if (!dragIcon.enabled)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.slotIcon[slotNum];
            }
        }
        else
        {
            if (dragIcon.enabled)
                dragIcon.enabled = false;
        }
    }
}
