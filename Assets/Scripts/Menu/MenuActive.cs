using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActive : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.shop || GameManager.Instance.equipShop || GameManager.Instance.talkEvent)
                return;

            if (!menu.activeSelf)
            {
                GameManager.Instance.PauseGame();
                GameManager.Instance.CursorOn();
                menu.SetActive(true);
            }
            else
            {
                GameManager.Instance.ResumeGame();
                GameManager.Instance.CursorOff();
                menu.SetActive(false);
            }
        }
    }
}
