using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    private Vector3 distance;

    [SerializeField]
    private GameObject shopCanvas;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.equipShop || GameManager.Instance.talkEvent)
            return;

        distance = new Vector3(player.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - gameObject.transform.position.z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!shopCanvas.activeSelf && Mathf.Abs(distance.magnitude) < 2.5f)
            {
                GameManager.Instance.OpenShop();
                GameManager.Instance.CursorOn();
                shopCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && shopCanvas.activeSelf)
        {
            GameManager.Instance.CloseShop();
            GameManager.Instance.CursorOff();
            shopCanvas.SetActive(false);
        }
    }
}
