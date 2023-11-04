using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool IsBackgroundMute => _backgroundAS.mute;
    public bool IsButtonClickMute => _buttonClickAS.mute;

    [SerializeField] private AudioSource _backgroundAS;
    [SerializeField] private AudioSource _buttonClickAS;
    [SerializeField] private AudioSource _selectedAS;

    [SerializeField] private AudioClip _selectedLoss;
    [SerializeField] private AudioClip _selectedComplete;

    public void PlayClickSound() => _buttonClickAS.Play();

    public void PlaySelectedComplete()
    {
        _selectedAS.clip = _selectedComplete;
        _selectedAS.Play();
    }

    public void PlaySelectedLossSound()
    {
        _selectedAS.clip = _selectedLoss;
        _selectedAS.Play();
    }

    public void BackgroundASMute(bool mute)
    {
        _backgroundAS.mute = mute;
    }

    public void ButtonClickASMute(bool mute)
    {
        _buttonClickAS.mute = mute;
        _selectedAS.mute = mute;
    }
}