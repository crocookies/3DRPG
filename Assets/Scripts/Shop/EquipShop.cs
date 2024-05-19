using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipShop : MonoBehaviour
{
    public ShopSlot[] slots;

    void Start()
    {
        slots = GetComponentsInChildren<ShopSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
