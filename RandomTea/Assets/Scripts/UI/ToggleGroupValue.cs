using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupValue : MonoBehaviour
{
    public List<Toggle> m_toggleList;

    private void Awake()
    {
        m_toggleList = new List<Toggle>();
        foreach (var toggle in gameObject.GetComponentsInChildren<Toggle>())
        {
            m_toggleList.Add(toggle);
        }
    }

    public Toggle GetActiveToggle()
    {
        foreach (var toggle in m_toggleList)
        {
            if (toggle.isOn)
            {
                return toggle;
            }
        }
        return null;
    }
}
