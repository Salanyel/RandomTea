using UnityEngine;

public class ButtonBarButton : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_panelToOpen = null;

    [SerializeField]
    protected GameObject[] m_panelsToClose = null;

    public virtual void OnClick()
    {
        foreach(var panelToClose in m_panelsToClose)
        {
            panelToClose.SetActive(false);
        }

        m_panelToOpen.SetActive(true);
    }
}
