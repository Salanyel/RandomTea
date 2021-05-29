using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfusionComponent : MonoBehaviour
{
    [SerializeField]
    private Text m_temperature = null;

    [SerializeField]
    private Text m_temperatureBase = null;

    [SerializeField]
    private Text m_infusionTime = null;

    public void SetInfusion(TeaData teaData)
    {
        SetTemperature(teaData.m_temperature, teaData.m_temperatureBase);
        SetInfusionTime(teaData.m_minInfusionTime, teaData.m_maxInfusionTime);
    }

    private void SetTemperature(int temperature, TemperatureBase temperatureBase)
    {
        string temperatureBaseString = string.Empty;

        m_temperature.text = $"{temperature}";

        switch (temperatureBase)
        {
            case TemperatureBase.Celsius:
                temperatureBaseString = "c";
                break;

            default:
                temperatureBaseString = "F";
                break;
        }

        m_temperatureBase.text = temperatureBaseString;
    }

    private void SetInfusionTime(int min, int max)
    {
        m_infusionTime.text = $"{min} - {max} min";
    }
}
