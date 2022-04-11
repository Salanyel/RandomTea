using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DependentSlider : MonoBehaviour
{
    enum BehaviourToDetect
    {
        None = 0,
        TargetAlwaysHigherThanCurrent,
        TargetAlwaysLesserThanCurrent,
    }

    [SerializeField]
    private BehaviourToDetect m_doBehaviourWhen = BehaviourToDetect.None;

    [SerializeField]
    private Slider m_currentSlider = null;
    [SerializeField]
    private Slider m_targetSlider = null;

    private void OnEnable()
    {
        m_currentSlider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        m_currentSlider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float newValue)
    {
        switch(m_doBehaviourWhen)
        {
            case BehaviourToDetect.TargetAlwaysHigherThanCurrent:
                TargetAlwaysHigherThanCurrent(newValue);
                break;

            case BehaviourToDetect.TargetAlwaysLesserThanCurrent:
                TargetAlwaysLesserThanCurrent(newValue);
                break;

            default:
                break;
        }       

    }

    private void TargetAlwaysHigherThanCurrent(float newValue)
    {
        if (m_currentSlider.value >= m_targetSlider.value)
        {
            m_targetSlider.value = m_currentSlider.value + 1;
        }
    }

    private void TargetAlwaysLesserThanCurrent(float newValue)
    {
        if (m_currentSlider.value <= m_targetSlider.value)
        {
            m_targetSlider.value = m_currentSlider.value - 1;
        }
    }
}
