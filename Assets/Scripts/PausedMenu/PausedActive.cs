using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedActive : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.inven || GameManager.Instance.shop)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
