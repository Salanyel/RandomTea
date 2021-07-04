using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaDetailButton : MonoBehaviour
{
    private GameObject m_panelToClose;
    private GameObject m_panelToOpen;

    private TeaDetailForm m_teaDetailForm;

    private void Awake()
    {
        m_panelToClose = FindObjectOfType<TeaListForm>().gameObject;
        m_teaDetailForm = Resources.FindObjectsOfTypeAll<TeaDetailForm>()[0];
        m_panelToOpen = m_teaDetailForm.gameObject;
    }

    public void OnClick()
    {
        TeaData teaData = GetComponent<TeaUIComponent>().GetTeaData();

        m_panelToClose.SetActive(false);

        m_teaDetailForm.SetTeaDetail(teaData);
        m_panelToOpen.SetActive(true);
    }
}
