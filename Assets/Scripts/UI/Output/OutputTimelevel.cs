using TMPro;
using UnityEngine;
using Zenject;

public class OutputTimelevel : MonoBehaviour
{
    private Timerlevel _timerlevel;
    private TMP_Text _timeText;

    [Inject]
    private void Construct(Timerlevel timerlevel)
    {
        _timerlevel = timerlevel;

        _timerlevel.OnTimeChange += OutputText;
    }

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();
    }

    private void OnDestroy()
    {
        _timerlevel.OnTimeChange -= OutputText;
    }

    private void OutputText(float text)
    {
        if (text <= 5)
            _timeText.color = Color.red;
        else _timeText.color = Color.white;

        _timeText.text = text.ToString("F0");
    }
}
