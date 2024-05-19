using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public enum Type { BGM, SE }
    public Type type;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        switch (type)
        {
            case Type.BGM:
                slider.value = Player.instance.BGMValue;
                break;
            case Type.SE:
                slider.value = Player.instance.SEValue;
                break;
        }
    }

    void Update()
    {
        switch (type)
        {
            case Type.BGM:
                Player.instance.BGMValue = slider.value;
                break;
            case Type.SE:
                Player.instance.SEValue = slider.value;
                break;
        }
    }
}
