using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGUI : MonoBehaviour
{
    [SerializeField]
    private Image HPBar;
    [SerializeField]
    private Image MPBar;
    [SerializeField]
    private Image SPBar;

    [SerializeField]
    private Text LVText;
    [SerializeField]
    private Text HPText;
    [SerializeField]
    private Text MPText;

    public GameObject staminaBG;

    void Start()
    {
        
    }

    void Update()
    {
        HPBar.fillAmount = Player.instance.curHP / Player.instance.maxHP;
        MPBar.fillAmount = Player.instance.curMP / Player.instance.maxMP;
        SPBar.fillAmount = Player.instance.curSP / Player.instance.maxSP;

        LVText.text = "LV " + (Player.instance.lv + 1).ToString();
        HPText.text = Player.instance.curHP.ToString("F0") + " / " + Player.instance.maxHP.ToString("F0");
        MPText.text = Player.instance.curMP.ToString("F0") + " / " + Player.instance.maxMP.ToString("F0");

        if (Player.instance.curSP >= Player.instance.maxSP)
        {
            staminaBG.SetActive(false);
            SPBar.enabled = false;
        }
        else
        {
            staminaBG.SetActive(true);
            SPBar.enabled = true;
        }
    }
}
