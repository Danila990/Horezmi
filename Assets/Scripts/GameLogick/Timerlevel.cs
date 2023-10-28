using TMPro;
using UnityEngine;

public class Timerlevel : MonoBehaviour
{
    [SerializeField] private float _startTime = 30;
    [SerializeField] private TMP_Text _textTimer;
    [SerializeField] private float _timeLimit = 45;
    [SerializeField] private float _selectedComplete = 15;
    [SerializeField] private float _selectedLoss = -30;
    private bool _isPlaying => _levelManager.IsPlayGame;

    private float _currentTime = 0;
    private LevelManager _levelManager;
    private NumberSelect _numberSelect;

    private void OnDestroy()
    {
        _levelManager.OnStartGame -= RestartTimer;
        _numberSelect.OnSelectComplete -= SelectedComplete;
        _numberSelect.OnSelectLoss -= SelectedLoss;
    }

    private void Update()
    {
        if (!_isPlaying) return;

        _currentTime -= Time.deltaTime;
        OutputText(_currentTime);

        if (_currentTime <= 0)
            _levelManager.GameOver();
    }

    public void Init(LevelManager levelManager, NumberSelect numberSelect)
    {
        _levelManager = levelManager;
        _numberSelect = numberSelect;
        _textTimer = _textTimer.GetComponent<TMP_Text>();

        RestartTimer();

        _levelManager.OnStartGame += RestartTimer;
        _numberSelect.OnSelectComplete += SelectedComplete;
        _numberSelect.OnSelectLoss += SelectedLoss;
    }

    private void SelectedComplete()
    {
        if (_currentTime + _selectedComplete >= _timeLimit)
            _currentTime = _timeLimit;
        else _currentTime += _selectedComplete;

        OutputText(_currentTime);
    }

    private void SelectedLoss()
    {
        if (_currentTime + _selectedLoss <= 0)
        {
            _currentTime = 0;
            _levelManager.GameOver();
        }
        else
            _currentTime += _selectedLoss;

        OutputText(_currentTime);
    }

    private void OutputText(float text)
    {
        if (text <= 5)
            _textTimer.color = Color.red;
        else _textTimer.color = Color.white;

        _textTimer.text = text.ToString("F0");
    }

    private void RestartTimer()
    {
        _currentTime = _startTime;
        OutputText(_startTime);
    }
}