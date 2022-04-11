using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int m_poolMaxSize = 20;
    public GameObject ObjectSample = null;

    private int m_objectInUse = 0;
    private Queue<GameObject> m_availableObjects = null;

    private void Awake()
    {
        m_availableObjects = new Queue<GameObject>(m_poolMaxSize);

        for(int i = 0; i < m_poolMaxSize; ++i)
        {
            GameObject newObject = Instantiate<GameObject>(ObjectSample);
            ResetObject(newObject);
            m_availableObjects.Enqueue(newObject);
        }
    }

    private void ResetObject(GameObject objectToReset)
    {
        objectToReset.SetActive(false);
    }

    private void SetObject(GameObject objectToSet)
    {
        objectToSet.SetActive(true);
    }

    public GameObject Loan()
    {
        GameObject loanedObject = null;

        if (m_objectInUse < m_poolMaxSize)
        {
            loanedObject = m_availableObjects.Dequeue();
            SetObject(loanedObject);
        }

        return loanedObject;
    }

    public void Return(GameObject objectReturned)
    {
        ResetObject(objectReturned);
        m_availableObjects.Enqueue(objectReturned);
    }
}
