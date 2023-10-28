using System;
using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    public event Action<SettingData> OnChangeLevelSetting;

    [SerializeField] private SettingData[] _levelSetting;
    [SerializeField] private int _currentIndexSetting = 0;
    [SerializeField] private int _nextUpdateIndex = 10;

    private LevelManager _levelManager;
    private NumberSelect _numberSelect;
    private int _counterNextUpdate = 0;

    private void OnDestroy()
    {
        _levelManager.OnStartGame -= StartGame;
        _numberSelect.OnSelectComplete -= SelectedComplete;
    }

    public void Init(LevelManager levelManager, NumberSelect numberSelect)
    {
        _numberSelect = numberSelect;
        _levelManager = levelManager;

        _levelManager.OnStartGame += StartGame;
        _numberSelect.OnSelectComplete += SelectedComplete;
    }

    public SettingData GetCurrentSetting() => _levelSetting[_currentIndexSetting];

    private void UpdateIndexSetting()
    {
        if (_currentIndexSetting + 1 >= _levelSetting.Length) return;

        _currentIndexSetting++;
        OnChangeLevelSetting?.Invoke(GetCurrentSetting());
    }

    private void StartGame()
    {
        _currentIndexSetting = 0;
        _counterNextUpdate = 0;
    }

    private void SelectedComplete()
    {
        _counterNextUpdate++;
        if(_counterNextUpdate >= _nextUpdateIndex)
        {
            UpdateIndexSetting();

            _counterNextUpdate = 0;
        }
    }
}