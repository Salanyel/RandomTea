using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaUIComponent : MonoBehaviour
{
    [SerializeField]
    private CaffeineLevelComponent m_caffeineLevel = null;

    [SerializeField]
    private TeaTypeComponent m_teaType = null;

    [SerializeField]
    private InfusionComponent m_infusion = null;

    [SerializeField]
    private Text m_teaName = null;

    [SerializeField]
    private Text m_teaBrand = null;

    private TeaData m_teaData;

    public void Initialize(TeaData teaData)
    {
        m_teaData = teaData;

        m_teaName.text = m_teaData.m_name;
        m_teaBrand.text = m_teaData.m_brand;

        m_caffeineLevel.SetCaffeineLevel(m_teaData);
        m_teaType.SetTeaType(m_teaData);
        m_infusion.SetInfusion(m_teaData);
    }

    public TeaData GetTeaData()
    {
        return m_teaData;
    }
}
