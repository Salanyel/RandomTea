using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaDetailForm : MonoBehaviour
{
    private TeaData m_teaData;

    [SerializeField]
    private Text m_teaName = null;

    [SerializeField]
    private Text m_teaBrand = null;

    [SerializeField]
    private TeaTypeComponent m_teaType = null;

    [SerializeField]
    private InfusionComponent m_teaInfusion = null;

    [SerializeField]
    private CaffeineLevelComponent m_caffeine = null;

    [SerializeField]
    private Text m_ingredients = null;

    public void SetTeaDetail(TeaData teaData)
    {
        m_teaData = teaData;

        Intialize();
    }

    private void Intialize()
    {
        m_teaName.text = m_teaData.m_name;
        m_teaBrand.text = m_teaData.m_brand;
        m_ingredients.text = m_teaData.m_ingredients;

        m_teaType.SetTeaType(m_teaData);
        m_teaInfusion.SetInfusion(m_teaData);
        m_caffeine.SetCaffeineLevel(m_teaData);
    }
}
