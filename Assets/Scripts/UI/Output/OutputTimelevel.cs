using TMPro;
using UnityEngine;
using Zenject;

public class OutputTimelevel : MonoBehaviour
{
    private Timerlevel _timerlevel;
    private NumberSelect _numberSelect;
    private Timer _timerSelect;
    private TMP_Text _timeText;

    [Inject]
    private void Construct(Timerlevel timerlevel,NumberSelect numberSelect )
    {
        _timerlevel = timerlevel;
        _numberSelect = numberSelect;

        _timerlevel.OnTimeChange += OutputText;
        _numberSelect.OnSelectComplete += SelectedComplete;
        _numberSelect.OnSelectLoss += SelectedLoss;
    }

    private void Awake()
    {
        _timerSelect = new Timer(1.5f);
        _timeText = GetComponent<TMP_Text>();
    }

    private void OnDestroy()
    {
        _timerlevel.OnTimeChange -= OutputText;
        _numberSelect.OnSelectComplete -= SelectedComplete;
        _numberSelect.OnSelectLoss -= SelectedLoss;
    }

    private void OutputText(float timer)
    {
        if(_timerSelect.IsTimerEnd)
            if (timer <= 5)
                _timeText.color = Color.red;
            else _timeText.color = Color.white;

        _timeText.text = timer.ToString("F0");
    }

    private void SelectedComplete()
    {
        _timerSelect.StartTime();
        _timeText.color = Color.green;
    }

    private void SelectedLoss()
    {
        _timerSelect.StartTime();

        _timeText.color = Color.red;
    }
}