using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler
{
    public enum Type { Resume, Save, Quit }
    public Type type;

    [SerializeField]
    private GameObject menu;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case Type.Resume:
                GameManager.Instance.ResumeGame();
                GameManager.Instance.CursorOff();
                menu.SetActive(false);
                break;
            case Type.Save:
                GameManager.Instance.SaveGame();
                break;
            case Type.Quit:
                Application.Quit();
                break;
        }
    }
}
