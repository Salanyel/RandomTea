using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaffeineLevelComponent : MonoBehaviour
{
    [SerializeField]
    private Image m_caffeineLevel = null;

    public void SetCaffeineLevel(TeaData teaData)
    {
        switch (teaData.m_caffeineDegree)
        {
            case CaffeineDegree.Low:
                m_caffeineLevel.color = Color.yellow;
                break;

            case CaffeineDegree.Middle:
                m_caffeineLevel.color = Color.gray;
                break;

            case CaffeineDegree.None:
                m_caffeineLevel.color = Color.white;
                break;

            case CaffeineDegree.High:
            default:
                m_caffeineLevel.color = Color.black;
                break;
        }
    }
}
