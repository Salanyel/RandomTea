using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBarRandomTeaButton : ButtonBarButton
{

    private TeaManager m_teaManager;
    private TeaDetailForm m_teaDetailForm;

    private void Awake()
    {
        m_teaManager = FindObjectOfType<TeaManager>();
        m_teaDetailForm = FindObjectOfType<TeaDetailForm>();
    }

    public override void OnClick()
    {
        TeaData randomTea = m_teaManager.GetRandomTea();
        m_teaDetailForm.SetTeaDetail(randomTea);

        base.OnClick();
    }
}
