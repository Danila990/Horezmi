using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool IsMute => _bacgroundSound.mute == true;

    [SerializeField] private AudioSource _bacgroundSound;
    [SerializeField] private AudioSource _buttonSound;

    public void PlayClickSound()
    {
        _buttonSound.Play();
    }

    public void UnmuteSound()
    {
        _bacgroundSound.mute = false;
        _buttonSound.mute = false;
    }

    public void MuteSound()
    {
        _bacgroundSound.mute = true;
        _buttonSound.mute = true;
    }
}