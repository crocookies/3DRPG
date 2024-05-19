using UnityEngine;
using UnityEngine.UI;

public class ScreenToggle : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        Player.instance.fullScreen = toggle.isOn;
    }
}
