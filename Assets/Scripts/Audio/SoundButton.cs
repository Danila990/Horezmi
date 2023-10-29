using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _enabledImage;
    [SerializeField] private Sprite _disableImage;

    private Image _image;
    private Button _button;
    private SoundManager _soundManager;
    private bool _isEnabled = false;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;

        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        UpdateImageButton();

        _button.onClick.AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    private void UpdateImageButton()
    {
        if (_isEnabled)
        {
            _image.sprite = _enabledImage;
            _soundManager.UnmuteSound();
        }
        else
        {
            _image.sprite = _disableImage;
            _soundManager.MuteSound();
        }
    }

    private void ClickButton()
    {
        if(_isEnabled)
            _isEnabled = false;
        else _isEnabled = true;

        _soundManager.PlayClickSound();

        UpdateImageButton();
    }
}