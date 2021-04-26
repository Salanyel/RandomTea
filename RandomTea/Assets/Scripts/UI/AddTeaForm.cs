using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddTeaForm : MonoBehaviour
{
    public InputField m_nameInputField;
    public InputField m_brandInputField;
    public ToggleGroupValue m_teaTypeToggleGroup;
    public InputField m_temperatureInputField;
    public ToggleGroupValue m_temperatureToggleGroup;
    public Slider m_timeMinSlider;
    public Slider m_timeMaxSlider;
    public Slider m_caffeineSlider;
    public InputField m_ingredientInputField;
    public Button m_addTeaButton;

    public void OnAddTeaClicked()
    {
        TeaData teaData = new TeaData();
        teaData.m_name = m_nameInputField.text;
        teaData.m_brand = m_brandInputField.text;
        teaData.m_minInfusionTime = (int)m_timeMinSlider.value;
        teaData.m_maxInfusionTime = (int)m_timeMaxSlider.value;
        teaData.m_ingredients = m_ingredientInputField.text;

        try
        {
            teaData.m_temperature = Int32.Parse(m_temperatureInputField.text);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{m_temperatureInputField.text}'");
            teaData.m_temperature = 0;
        }


        // set tea type
        switch(m_teaTypeToggleGroup.GetActiveToggle().name)
        {
            case "Green":
                teaData.m_teaType = TeaType.GreenTea;
                break;
            case "Infusion":
                teaData.m_teaType = TeaType.Infusion;
                break;
            case "White":
                teaData.m_teaType = TeaType.WhiteTea;
                break;
            case "Black":
                teaData.m_teaType = TeaType.BlackTea;
                break;
            case "Oolong":
                teaData.m_teaType = TeaType.OolongTea;
                break;
            case "Rooibos":
                teaData.m_teaType = TeaType.Rooibos;
                break;
            default:
                teaData.m_teaType = TeaType.Infusion;
                break;
        }

        // set temperature base
        switch (m_temperatureToggleGroup.GetActiveToggle().name)
        {
            case "Celsius":
                teaData.m_temperatureBase = TemperatureBase.Celsius;
                break;
            case "Farenheit":
                teaData.m_temperatureBase = TemperatureBase.Farenheit;
                break;
            default:
                teaData.m_temperatureBase = TemperatureBase.Celsius;
                break;
        }

        // set caffeine degree
        switch((int)m_caffeineSlider.value)
        {
            case 0:
                teaData.m_caffeineDegree = CaffeineDegree.None;
                break;
            case 1:
                teaData.m_caffeineDegree = CaffeineDegree.Low;
                break;
            case 2:
                teaData.m_caffeineDegree = CaffeineDegree.Middle;
                break;
            case 3:
                teaData.m_caffeineDegree = CaffeineDegree.High;
                break;
        }

        Debug.Log(teaData.m_name);
        Debug.Log(teaData.m_brand);
        Debug.Log(teaData.m_temperatureBase);
        Debug.Log(teaData.m_temperature);


    }
}
