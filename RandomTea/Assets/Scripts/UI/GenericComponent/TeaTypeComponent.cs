using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaTypeComponent : MonoBehaviour
{
    [SerializeField]
    private Image m_teaType = null;

    public void SetTeaType(TeaData teaData)
    {
        switch (teaData.m_teaType)
        {
            case TeaType.BlackTea:
                m_teaType.color = Color.black;
                break;

            case TeaType.GreenTea:
                m_teaType.color = Color.green;
                break;

            case TeaType.Infusion:
                m_teaType.color = Color.blue;
                break;

            case TeaType.OolongTea:
                m_teaType.color = Color.grey;
                break;

            case TeaType.Rooibos:
                m_teaType.color = Color.red;
                break;

            case TeaType.WhiteTea:
                m_teaType.color = Color.white;
                break;

            default:
                break;
        }
    }
}
