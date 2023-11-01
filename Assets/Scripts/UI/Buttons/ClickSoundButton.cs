using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClickSoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _enabledImage;

    protected bool _isEnabled = false;
    protected SoundManager _soundManager;
    private Sprite _disableSprite;
    private Image _image;
    private Button _button;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;

        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _disableSprite = GetComponent<Image>().sprite;
        CheckState();
        UpdateImageButton();

        _button.onClick.AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        if (_isEnabled)
            _isEnabled = false;
        else _isEnabled = true;

        _soundManager.PlayClickSound();

        MuteSound(!_isEnabled);
        UpdateImageButton();
    }

    private void UpdateImageButton()
    {
        if (_isEnabled)
            _image.sprite = _enabledImage;
        else
            _image.sprite = _disableSprite;
    }

    protected virtual void CheckState()
    {
        _isEnabled = !_soundManager.IsButtonClickMute;
    }

    protected virtual void MuteSound(bool mute)
    {
        _soundManager.ButtonClickASMute(mute);
    }
}