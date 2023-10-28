using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public bool IsMute => _bacgroundSound.mute == true;

    [SerializeField] private AudioSource _bacgroundSound;
    [SerializeField] private AudioSource _buttonSound;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }

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