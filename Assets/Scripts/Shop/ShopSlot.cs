using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    private int slotNum;

    private float lastClick;

    private bool doubleClick;

    GameObject itemIcon;
    GameObject itemName;
    GameObject itemPrice;

    void Start()
    {
        slotNum = transform.GetSiblingIndex() + 1;

        itemIcon = transform.GetChild(0).gameObject;
        itemName = transform.GetChild(1).gameObject;
        itemPrice = transform.GetChild(2).gameObject;

        itemIcon.GetComponent<Image>().sprite = Player.instance.itemIcon[slotNum];
        itemName.GetComponent<Text>().text = Player.instance.itemName[slotNum];
        itemPrice.GetComponent<Text>().text = Player.instance.itemPrice[slotNum].ToString();
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

        BuyItem();
    }

    private void BuyItem()
    {
        if (doubleClick)
        {
            doubleClick = false;

            if (Player.instance.money >= Player.instance.itemPrice[slotNum])
            {
                SoundEffect.instance.Shop();
                Player.instance.money -= Player.instance.itemPrice[slotNum];
                GameManager.Instance.AddItem(slotNum, 1);
            }
        }
        else
        {
            doubleClick = true;
        }
    }
}
