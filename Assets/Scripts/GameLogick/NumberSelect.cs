using System;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelect : MonoBehaviour
{
    public const string SELECTED_ANIMATION_ID = "selected";

    public event Action OnSelectComplete;
    public event Action OnSelectLoss;

    [SerializeField] private float _selectCompleteTIme = 15;

    private bool _isPlayGame => _levelManager.IsPlayGame;

    private SoundManager _soundManager;
    private NumberGenerator _numberGenerator;
    private LevelManager _levelManager;
    private Timerlevel _timerlevel;
    private List<Number> _numbersList = new List<Number>(3);

    private void OnDestroy()
    {
        _levelManager.OnStartGame -= ResetNumbers;
    }

    public void Init(LevelManager levelManager,
        NumberGenerator numberGenerator, SoundManager soundManager,
        Timerlevel timerlevel)
    {
        _levelManager = levelManager;
        _numberGenerator = numberGenerator;
        _soundManager = soundManager;
        _timerlevel = timerlevel;

        _levelManager.OnStartGame += ResetNumbers;
    }

    public void NumberUIClick(Number numberUIClick)
    {
        if (_numbersList.Count >= 3 || !_isPlayGame || CheckDublicate(numberUIClick)) return;

        AddNumberLogick(numberUIClick);

        if (_numbersList.Count != 3) return;

        NumberSumResult();

        ResetNumbers();
    }

    private bool CheckDublicate(Number numberUIClick) 
    {
        foreach (Number numberUI in _numbersList)
            if (numberUI == numberUIClick)
            {
                foreach (Number numberUI2 in _numbersList)
                {
                    numberUI2.GetComponent<Animator>().SetBool(SELECTED_ANIMATION_ID, false);
                    numberUI2.DeactivateLight();
                }

                ResetNumbers();
                return true;
            }

        return false;
    }

    private void AddNumberLogick(Number numberUIClick)
    {
        if ((_numbersList.Count == 0 || _numbersList.Count == 2) && numberUIClick.TypeNumber != TypeNumber.Default)
            return;

        _numbersList.Add(numberUIClick);
        numberUIClick.GetComponent<Animator>().SetBool(SELECTED_ANIMATION_ID, true);
        numberUIClick.ActivateLight();
        _soundManager.PlayClickSound();
    }

    private void NumberSumResult()
    {
        if (_numberGenerator.CheckSelectResult(_numbersList))
            OnSelectComplete?.Invoke();
        else
            OnSelectLoss?.Invoke();

        _numberGenerator.OverwriteNumbers(_numbersList);
    }

    private void ResetNumbers() => _numbersList.Clear();
}