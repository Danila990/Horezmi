using UnityEngine;

[System.Serializable]
public struct SettingData
{
    public float TimeLimit => _timeLimit;
    public float SelectedComplete => _selectedComplete;
    public float SelectedLoss => _selectedLoss;
    public int MinValueNumber => _minValueNumber;
    public int MaxValueNumber => _maxValueNumber;
    public ChanceType[] ChanceType => _chanceType;


    [SerializeField,Range(30, 90)] private float _timeLimit;
    [SerializeField, Range(5, 30)] private float _selectedComplete;
    [SerializeField,Range(5, 30)] private float _selectedLoss;
    [SerializeField, Range(1, 50)] private int _minValueNumber;
    [SerializeField,Range(1,100)] private int _maxValueNumber;
    [SerializeField] private ChanceType[] _chanceType;
}