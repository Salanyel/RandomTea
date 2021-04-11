using UnityEngine;

public class ButtonBarButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_panelToOpen = null;

    [SerializeField]
    private GameObject[] m_panelsToClose = null;

    public void OnClick()
    {
        foreach(var panelToClose in m_panelsToClose)
        {
            panelToClose.SetActive(false);
        }

        m_panelToOpen.SetActive(true);
    }
}
