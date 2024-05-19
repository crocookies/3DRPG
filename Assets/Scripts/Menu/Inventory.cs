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
    public string slotType;
    public string otherSlotType;

    [SerializeField]
    private Image dragIcon;

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
        
    }

    private void LateUpdate()
    {
        DragItem();
    }

    public void SlotChange(int slotNum1, int slotNum2, string slotType1, string slotType2)
    {
        if (!onSlot)
            return;

        if (slotType1 == "½½·Ô" && slotType2 == "½½·Ô" && Player.instance.slotCnt[slotNum1] > 0)
        {
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

            int tmpprice = Player.instance.slotPrice[slotNum1];
            Player.instance.slotPrice[slotNum1] = Player.instance.slotPrice[slotNum2];
            Player.instance.slotPrice[slotNum2] = tmpprice;

            Sprite tmpicon = Player.instance.slotIcon[slotNum1];
            Player.instance.slotIcon[slotNum1] = Player.instance.slotIcon[slotNum2];
            Player.instance.slotIcon[slotNum2] = tmpicon;
        }
        else if (slotType1 == "½½·Ô" && slotType2 == "Äü½½·Ô" && Player.instance.slotCnt[slotNum1] > 0)
        {
            int tmpid = Player.instance.slotId[slotNum1];
            Player.instance.slotId[slotNum1] = Player.instance.quickSlotId[slotNum2];
            Player.instance.quickSlotId[slotNum2] = tmpid;

            int tmpcnt = Player.instance.slotCnt[slotNum1];
            Player.instance.slotCnt[slotNum1] = Player.instance.quickSlotCnt[slotNum2];
            Player.instance.quickSlotCnt[slotNum2] = tmpcnt;

            string tmpname = Player.instance.slotName[slotNum1];
            Player.instance.slotName[slotNum1] = Player.instance.quickSlotName[slotNum2];
            Player.instance.quickSlotName[slotNum2] = tmpname;

            float tmprecoveryhp = Player.instance.slotRecoveryHP[slotNum1];
            Player.instance.slotRecoveryHP[slotNum1] = Player.instance.quickSlotRecoveryHP[slotNum2];
            Player.instance.quickSlotRecoveryHP[slotNum2] = tmprecoveryhp;

            float tmprecoverymp = Player.instance.slotRecoveryMP[slotNum1];
            Player.instance.slotRecoveryMP[slotNum1] = Player.instance.quickSlotRecoveryMP[slotNum2];
            Player.instance.quickSlotRecoveryMP[slotNum2] = tmprecoverymp;

            int tmpprice = Player.instance.slotPrice[slotNum1];
            Player.instance.slotPrice[slotNum1] = Player.instance.quickSlotPrice[slotNum2];
            Player.instance.quickSlotPrice[slotNum2] = tmpprice;

            Sprite tmpicon = Player.instance.slotIcon[slotNum1];
            Player.instance.slotIcon[slotNum1] = Player.instance.quickSlotIcon[slotNum2];
            Player.instance.quickSlotIcon[slotNum2] = tmpicon;
        }
        else if(slotType1 == "Äü½½·Ô" && slotType2 == "½½·Ô" && Player.instance.quickSlotCnt[slotNum1] > 0)
        {
            int tmpid = Player.instance.quickSlotId[slotNum1];
            Player.instance.quickSlotId[slotNum1] = Player.instance.slotId[slotNum2];
            Player.instance.slotId[slotNum2] = tmpid;

            int tmpcnt = Player.instance.quickSlotCnt[slotNum1];
            Player.instance.quickSlotCnt[slotNum1] = Player.instance.slotCnt[slotNum2];
            Player.instance.slotCnt[slotNum2] = tmpcnt;

            string tmpname = Player.instance.quickSlotName[slotNum1];
            Player.instance.quickSlotName[slotNum1] = Player.instance.slotName[slotNum2];
            Player.instance.slotName[slotNum2] = tmpname;

            float tmprecoveryhp = Player.instance.quickSlotRecoveryHP[slotNum1];
            Player.instance.quickSlotRecoveryHP[slotNum1] = Player.instance.slotRecoveryHP[slotNum2];
            Player.instance.slotRecoveryHP[slotNum2] = tmprecoveryhp;

            float tmprecoverymp = Player.instance.quickSlotRecoveryMP[slotNum1];
            Player.instance.quickSlotRecoveryMP[slotNum1] = Player.instance.slotRecoveryMP[slotNum2];
            Player.instance.slotRecoveryMP[slotNum2] = tmprecoverymp;

            int tmpprice = Player.instance.quickSlotPrice[slotNum1];
            Player.instance.quickSlotPrice[slotNum1] = Player.instance.slotPrice[slotNum2];
            Player.instance.slotPrice[slotNum2] = tmpprice;

            Sprite tmpicon = Player.instance.quickSlotIcon[slotNum1];
            Player.instance.quickSlotIcon[slotNum1] = Player.instance.slotIcon[slotNum2];
            Player.instance.slotIcon[slotNum2] = tmpicon;
        }
        else if (slotType1 == "Äü½½·Ô" && slotType2 == "Äü½½·Ô" && Player.instance.quickSlotCnt[slotNum1] > 0)
        {
            int tmpid = Player.instance.quickSlotId[slotNum1];
            Player.instance.quickSlotId[slotNum1] = Player.instance.quickSlotId[slotNum2];
            Player.instance.quickSlotId[slotNum2] = tmpid;

            int tmpcnt = Player.instance.quickSlotCnt[slotNum1];
            Player.instance.quickSlotCnt[slotNum1] = Player.instance.quickSlotCnt[slotNum2];
            Player.instance.quickSlotCnt[slotNum2] = tmpcnt;

            string tmpname = Player.instance.quickSlotName[slotNum1];
            Player.instance.quickSlotName[slotNum1] = Player.instance.quickSlotName[slotNum2];
            Player.instance.quickSlotName[slotNum2] = tmpname;

            float tmprecoveryhp = Player.instance.quickSlotRecoveryHP[slotNum1];
            Player.instance.quickSlotRecoveryHP[slotNum1] = Player.instance.quickSlotRecoveryHP[slotNum2];
            Player.instance.quickSlotRecoveryHP[slotNum2] = tmprecoveryhp;

            float tmprecoverymp = Player.instance.quickSlotRecoveryMP[slotNum1];
            Player.instance.quickSlotRecoveryMP[slotNum1] = Player.instance.quickSlotRecoveryMP[slotNum2];
            Player.instance.quickSlotRecoveryMP[slotNum2] = tmprecoverymp;

            int tmpprice = Player.instance.quickSlotPrice[slotNum1];
            Player.instance.quickSlotPrice[slotNum1] = Player.instance.quickSlotPrice[slotNum2];
            Player.instance.quickSlotPrice[slotNum2] = tmpprice;

            Sprite tmpicon = Player.instance.quickSlotIcon[slotNum1];
            Player.instance.quickSlotIcon[slotNum1] = Player.instance.quickSlotIcon[slotNum2];
            Player.instance.quickSlotIcon[slotNum2] = tmpicon;
        }

        slotNum = otherSlotNum;
        slotType = otherSlotType;
    }
    
    public void DragItem()
    {
        mousePos = Input.mousePosition;
        dragIcon.rectTransform.position = mousePos;
        
        if (draging)
        {
            if (slotType == "½½·Ô" && !dragIcon.enabled && Player.instance.slotId[slotNum] > 0)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.slotIcon[slotNum];
            }
            else if (slotType == "Äü½½·Ô" && !dragIcon.enabled && Player.instance.quickSlotId[slotNum] > 0)
            {
                dragIcon.enabled = true;
                dragIcon.sprite = Player.instance.quickSlotIcon[slotNum];
            }
        }
        else
        {
            if (dragIcon.enabled)
                dragIcon.enabled = false;
        }
    }
}
