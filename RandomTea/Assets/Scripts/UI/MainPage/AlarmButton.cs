using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_panelToClose = null;

    [SerializeField]
    private GameObject m_panelToOpen = null;

    public void OnClick()
    {
        m_panelToClose.SetActive(false);
        m_panelToOpen.SetActive(true);
    }
}
