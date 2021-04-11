using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDisplayTeas : MonoBehaviour
{
    private TeaManager m_teaManager;
    private Text m_text;

    private void Awake()
    {
        m_teaManager = FindObjectOfType<TeaManager>();
        m_text = GetComponent<Text>();
    }

    private void Update()
    {
        int size = m_teaManager.getTeas().Count;

        m_text.text = $"Number of Teas: {size}";
    }
}
