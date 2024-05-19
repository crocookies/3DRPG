using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipShopSlot : MonoBehaviour, IPointerClickHandler
{
    private int slotNum;

    private float lastClick;

    private bool doubleClick;

    GameObject equipIcon;
    GameObject equipName;
    GameObject equipPrice;

    void Start()
    {
        slotNum = transform.GetSiblingIndex() + 1;

        equipIcon = transform.GetChild(0).gameObject;
        equipName = transform.GetChild(1).gameObject;
        equipPrice = transform.GetChild(2).gameObject;

        equipIcon.GetComponent<Image>().sprite = Player.instance.equipIcon[slotNum];
        equipName.GetComponent<Text>().text = Player.instance.equipName[slotNum];
        equipPrice.GetComponent<Text>().text = Player.instance.equipPrice[slotNum].ToString();
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        lastClick += Time.unscaledDeltaTime;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        lastClick = 0;

        BuyEquip();
    }

    private void BuyEquip()
    {
        if (doubleClick)
        {
            doubleClick = false;

            if (Player.instance.money >= Player.instance.equipPrice[slotNum])
            {
                SoundEffect.instance.Shop();
                Player.instance.money -= Player.instance.equipPrice[slotNum];
                GameManager.Instance.AddEquip(slotNum);
            }
        }
        else
        {
            doubleClick = true;
        }
    }
}
