using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActive : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.shop)
            return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventory.activeSelf)
            {
                GameManager.Instance.OpenInventory();
                GameManager.Instance.CursorOn();
                inventory.SetActive(true);
            }
            else
            {
                GameManager.Instance.CloseInventory();
                GameManager.Instance.CursorOff();
                inventory.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inventory.activeSelf)
        {
            GameManager.Instance.CloseInventory();
            GameManager.Instance.CursorOff();
            inventory.SetActive(false);
        }
    }
}
