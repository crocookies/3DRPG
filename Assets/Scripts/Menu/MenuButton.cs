using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler
{
    public enum Type { Item, Equip, Setting, Quit }
    public Type type;

    [SerializeField]
    private GameObject inven;
    [SerializeField]
    private GameObject equip;
    [SerializeField]
    private GameObject setting;

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
            case Type.Item:
                equip.SetActive(false);
                setting.SetActive(false);
                inven.SetActive(true);
                break;
            case Type.Equip:
                inven.SetActive(false);
                setting.SetActive(false);
                equip.SetActive(true);
                break;
            case Type.Setting:
                inven.SetActive(false);
                equip.SetActive(false);
                setting.SetActive(true);
                break;
            case Type.Quit:
                GameManager.Instance.SaveGame();
                break;
        }
    }
}
