using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _enabledImage;
    [SerializeField] private Sprite _disableImage;
    [SerializeField] private Button _button;

    private void Start()
    {
        if (SoundManager.instance.IsMute)
            DisableImage();
        else
        {
            GetComponent<Image>().sprite = _enabledImage;
            SoundManager.instance.UnmuteSound();
        }

        _button.onClick.AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        if (SoundManager.instance.IsMute)
            EnableImage();
        else DisableImage();
    }

    private void EnableImage()
    {
        GetComponent<Image>().sprite = _enabledImage;
        SoundManager.instance.UnmuteSound();
        SoundManager.instance.PlayClickSound();
    }

    private void DisableImage() 
    {
        GetComponent<Image>().sprite = _disableImage;
        SoundManager.instance.MuteSound();
    }
}