using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool IsBackgroundMute => _backgroundAS.mute;
    public bool IsButtonClickMute => _buttonClickAS.mute;

    [SerializeField] private AudioSource _backgroundAS;
    [SerializeField] private AudioSource _buttonClickAS;

    public void PlayClickSound() => _buttonClickAS.Play();

    public void BackgroundASMute(bool mute)
    {
        _backgroundAS.mute = mute;
    }

    public void ButtonClickASMute(bool mute)
    {
        _buttonClickAS.mute = mute;
    }
}