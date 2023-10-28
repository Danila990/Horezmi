using UnityEngine;

[System.Serializable]
public struct SettingData
{
    public ChanceType[] ChanceType => _chanceType;
    public int MixRangeNumber => _mixRangeNumber;
    public int MaxRangeNumber => _maxRangeNumber;

    [SerializeField,Range(1,49)] private int _mixRangeNumber;
    [SerializeField,Range(1,99)] private int _maxRangeNumber;
    [SerializeField] private ChanceType[] _chanceType;
}