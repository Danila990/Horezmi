using TMPro;
using UnityEngine;
using Zenject;

public class OutputScoreLevel : MonoBehaviour
{
    private ScoreLevel _scoreLevel;
    private TMP_Text _timeText;

    [Inject]
    private void Construct(ScoreLevel scoreLevel)
    {
        _scoreLevel = scoreLevel;

        _scoreLevel.OnScoreChange += OutputText;
    }

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();
    }

    private void OnDestroy()
    {
        _scoreLevel.OnScoreChange -= OutputText;
    }

    private void OutputText(int score) => _timeText.text = score.ToString();
}