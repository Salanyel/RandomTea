using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public enum SliderType
    {
        Temperature = 0,
        Caffeine
    }

    public Slider m_slider;
    public Text m_text;
    public SliderType m_sliderType;

    private void Start()
    {
        SetTextValue();
    }

    public void OnValueChange()
    {
        SetTextValue();
    }

    private void SetTextValue()
    {
        switch (m_sliderType)
        {
            case SliderType.Temperature:
                if (m_slider.value == 16)
                {
                    m_text.text = "15+";
                }
                else
                {
                    m_text.text = m_slider.value.ToString();
                }
                break;

            case SliderType.Caffeine:
                string caffeineValue = string.Empty;
                int currentValue = (int)m_slider.value;
                                
                switch (currentValue)
                {
                    case 0:
                        caffeineValue = "No caffeine";
                        break;

                    case 1:
                        caffeineValue = "Low";
                        break;

                    case 2:
                        caffeineValue = "Medium";
                        break;

                    case 3:
                    default:
                        caffeineValue = "High";
                        break;
                }
                m_text.text = caffeineValue;
                break;
        }
    }
}
