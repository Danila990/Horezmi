using System;
using UnityEngine;
using Zenject;

public class Timerlevel : MonoBehaviour
{
    public event Action<float> OnTimeChange;

    [SerializeField,Range(25,60)] private float _startTime = 30;

    private float _selectedComplete = 15;
    private float _selectedLoss = 15;
    private float _timeLimit = 45;
    private float _currentTime = 0;
    private LevelManager _levelManager;
    private NumberSelect _numberSelect;
    private LevelSetting _levelSetting;

    [Inject]
    private void Construct(LevelManager levelManager, LevelSetting levelSetting,
        NumberSelect numberSelect)
    {
        _levelManager = levelManager;
        _numberSelect = numberSelect;
        _levelSetting = levelSetting;

        _levelSetting.OnChangeLevelSetting += UpdateSetting;
        _levelManager.OnRestartGame += RestartTimer;
        _levelManager.OnRevivalGame += RestartTimer;
        _numberSelect.OnSelectComplete += SelectedComplete;
        _numberSelect.OnSelectLoss += SelectedLoss;
    }

    private void Update()
    {
        if (!_levelManager.IsPlayGame) return;

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
            _levelManager.GameOver();

        OnTimeChange.Invoke(_currentTime);
    }

    private void OnDestroy()
    {
        _levelSetting.OnChangeLevelSetting -= UpdateSetting;
        _levelManager.OnRestartGame -= RestartTimer;
        _levelManager.OnRevivalGame += RestartTimer;
        _numberSelect.OnSelectComplete -= SelectedComplete;
        _numberSelect.OnSelectLoss -= SelectedLoss;
    }

    private void ChangeTime() => OnTimeChange?.Invoke(_currentTime);

    private void SelectedComplete()
    {
        if (_currentTime + _selectedComplete >= _timeLimit)
            _currentTime = _timeLimit;
        else _currentTime += _selectedComplete;

        ChangeTime();
    }

    private void SelectedLoss()
    {
        if (_currentTime - _selectedLoss <= 0)
        {
            _currentTime = 0;
            _levelManager.GameOver();
        }
        else
            _currentTime -= _selectedLoss;

        ChangeTime();
    }

    private void UpdateSetting(SettingData settingData)
    {
        _selectedComplete = settingData.SelectedComplete;
        _selectedLoss = settingData.SelectedLoss;
        _timeLimit = settingData.TimeLimit;
    }

    private void RestartTimer()
    {
        _currentTime = _startTime;
        ChangeTime();
    }
}