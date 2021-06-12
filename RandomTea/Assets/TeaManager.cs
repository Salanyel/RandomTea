using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TeaManager : MonoBehaviour
{
    private string m_filePath = string.Empty;
    private string m_fileName = "/teas.json";

    private List<TeaData> m_teasList = null;

    private void Awake()
    {
        m_filePath = Application.persistentDataPath + m_fileName;
        Debug.Log($"File path: {m_filePath}");

        LoadTeaFile();

        if (m_teasList.Count > 0)
        {
            return;
        }

        for(int i = 0; i < 5; i++)
        {
            TeaData test = new TeaData();

            test.m_name = $"Tea name: {i}";
            test.m_brand = $"Tea brand: {i}";
            test.m_ingredients = $"Tea ingerdients: {i}, StrawBerries, BlackTea, whatever, {i}";
            test.m_temperature = i * 15;
            test.m_teaType = TeaType.BlackTea;
            test.m_temperatureBase = TemperatureBase.Celsius;
            test.m_minInfusionTime = i;
            test.m_maxInfusionTime = 10 + i;

            AddTea(test, false);
        }

        SaveTeas();
    }

    private void LoadTeaFile()
    {
        m_teasList = new List<TeaData>();

        if (m_fileName == null)
        {
            return;
        }

        if (!File.Exists(m_filePath))
        {
            File.Create(m_filePath);
            Debug.Log($"File has been created at path: {m_filePath}");

            return;
        }

        string currentLine;
        TeaData currentTea;
        StreamReader reader = new StreamReader(m_filePath);

        while ((currentLine = reader.ReadLine()) != null)
        {
            currentTea = JsonUtility.FromJson<TeaData>(currentLine);
            m_teasList.Add(currentTea);
        }

        reader.Close();
    }

    private void SaveTeas()
    {
        if (m_fileName == null)
        {
            return;
        }

        //Function to clear the file
        System.IO.File.WriteAllText(m_filePath,string.Empty);

        StreamWriter writer = new StreamWriter(m_filePath, false);
        string currentLine;

        foreach(var tea in m_teasList)
        {
            currentLine = JsonUtility.ToJson(tea);
            writer.WriteLine(currentLine);
        }

        writer.Close();
    }

    public void AddTea(TeaData newTea, bool saveTeaFile = true)
    {
        m_teasList.Add(newTea);

        if (saveTeaFile)
        {
            SaveTeas();
        }
    }

    public List<TeaData> getTeas()
    {
        return m_teasList;
    }

    public TeaData GetRandomTea()
    {
        int randomIndex = (int) Random.Range(0f, m_teasList.Count);
        return m_teasList[randomIndex];
    }
}
