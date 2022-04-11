public enum TeaType
{
    Infusion = 0,
    GreenTea = 2,
    BlackTea = 4,
    WhiteTea = 8,
    Rooibos = 16,
    OolongTea = 32,
}

public enum CaffeineDegree
{
    None = 0,
    Low = 2,
    Middle = 4,
    High = 8,
}

public enum TemperatureBase
{
    Celsius = 0,
    Farenheit = 2,
}

public struct TeaData
{
    public string m_name;
    public string m_brand;

    public TeaType m_teaType;

    public int m_temperature;
    public TemperatureBase m_temperatureBase;

    public int m_minInfusionTime; // Time will be saved and loaded as seconds
    public int m_maxInfusionTime; // Time will be saved and loaded as seconds

    public CaffeineDegree m_caffeineDegree;
    public string m_ingredients;
}
