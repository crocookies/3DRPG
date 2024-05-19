using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipShopNPC : MonoBehaviour
{
    private Vector3 distance;

    public GameObject equipShopCanvas;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.shop || GameManager.Instance.talkEvent)
            return;

        distance = new Vector3(player.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - gameObject.transform.position.z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!GameManager.Instance.equipShop && Mathf.Abs(distance.magnitude) < 2.5f)
            {
                GameManager.Instance.OpenEquipShop();
                GameManager.Instance.CursorOn();
                equipShopCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && equipShopCanvas.activeSelf)
        {
            GameManager.Instance.CloseEquipShop();
            GameManager.Instance.CursorOff();
            equipShopCanvas.SetActive(false);
        }
    }
}
