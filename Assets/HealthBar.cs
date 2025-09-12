using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text valueText;

    public void SetMaxHealth(float max)
    {
        slider.maxValue = max;
        slider.value = max;
        UpdateText(max, max);
    }

    public void SetHealth(float current)
    {
        slider.value = current;
        UpdateText(current, slider.maxValue);
    }

    private void UpdateText(float current, float max)
    {
        if (valueText != null)
        {
            valueText.text = Mathf.CeilToInt(current) + " / " + Mathf.CeilToInt(max);
        }
    }
}
