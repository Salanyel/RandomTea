using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Pool))]
public class TeaListForm : MonoBehaviour
{
    [SerializeField]
    private int m_poolDisplay = 10;

    [SerializeField]
    private float m_spacing = 10;

    [SerializeField]
    private Transform m_content = null;

    private Pool m_pool = null;
    private TeaManager m_teaManager;
    private List<TeaData> m_teaData = null;

    private int m_currentIndex = 0;

    private float m_objectSize = 0f;
    private float m_halfSize = 0f;
    private float m_totalSize;
    private float m_elementSize;

    private Dictionary<int, GameObject> m_teaObjects = null;
    private List<int> m_keys;

    private void Awake()
    {
        m_pool = GetComponent<Pool>();
        m_keys = new List<int>(2 * m_poolDisplay + 1);
        m_teaManager = FindObjectOfType<TeaManager>();
        m_teaObjects = new Dictionary<int, GameObject>();
    }

    private void Start()
    {
        GetAndInitialize();
    }

    private void GetAndInitialize()
    {
        float m_halfSize = m_content.GetComponent<RectTransform>().sizeDelta.x / 2;
        m_objectSize = m_pool.ObjectSample.GetComponent<RectTransform>().sizeDelta.y;

        m_teaData = m_teaManager.getTeas();
        m_elementSize = m_objectSize + m_spacing;
        m_totalSize = m_teaData.Count * m_elementSize;

        RectTransform contentRectTransform = m_content.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, m_totalSize);

        m_currentIndex = 0;

        int max = (int)(Mathf.Min(m_teaData.Count, m_poolDisplay / 2));

        for (int i = 0; i < max; ++i)
        {
            PlaceObject(i);
        }
    }

    private void Update()
    {
        RectTransform current;

        foreach(var teaObject in m_teaObjects)
        {
            current = teaObject.Value.GetComponent<RectTransform>();
            teaObject.Value.GetComponent<RectTransform>().localPosition = new Vector2(513.5f, current.localPosition.y);
        }
    }

    private void PlaceObject(int currentIndex)
    {
        GameObject current = m_pool.Loan();
        current.name = currentIndex.ToString();
        current.transform.SetParent(m_content.transform);

        current.GetComponent<RectTransform>().localPosition = new Vector2(m_halfSize, - currentIndex * m_elementSize);
        float colorValue = ((float)(currentIndex)) / m_teaData.Count;
        current.GetComponent<Image>().color = new Color(colorValue, colorValue, colorValue);
        current.GetComponent<TeaUIComponent>().Initialize(m_teaData[currentIndex]);
        m_teaObjects.Add(currentIndex, current);
    }

    // x and y are between 0 and 1
    public void OnScrollListValueChanged(Vector2 newValue)
    {
        int currentIndex = (int)(Mathf.Round(m_totalSize * (1 - newValue.y) / m_elementSize));

        if (currentIndex != m_currentIndex)
        {
            m_currentIndex = currentIndex;

            int newMin = (int)Mathf.Max(0, m_currentIndex - m_poolDisplay / 2);
            int newMax = (int)Mathf.Min(m_currentIndex + m_poolDisplay / 2, m_teaData.Count - 1);

            Hide(newMin,newMax);
            Show(newMin,newMax);
        }
    }

    private void Hide(int min, int max)
    {
        m_keys.Clear();

        foreach(var teaDisplay in m_teaObjects)
        {
            if (teaDisplay.Key < min || teaDisplay.Key > max)
            {
                m_keys.Add(teaDisplay.Key);
                m_pool.Return(teaDisplay.Value);
            }
        }

        foreach(int key in m_keys)
        {
            m_teaObjects.Remove(key);
        }
    }

    private void Show(int min, int max)
    {
        m_keys.Clear();

        for(int i = min; i <= max; ++i)
        {
            if (!m_teaObjects.ContainsKey(i))
            {
                PlaceObject(i);
            }
        }
    }
}
