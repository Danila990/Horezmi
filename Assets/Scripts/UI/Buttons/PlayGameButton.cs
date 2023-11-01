using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class PlayGameButton : MonoBehaviour
{
    [Inject]
    private void Construct(SoundManager soundManager)
    {
        GetComponent<Button>().onClick.AddListener(() => SetupButton(soundManager));
    }

    private void SetupButton(SoundManager soundManager)
    {
        soundManager.PlayClickSound();
        SceneManager.LoadSceneAsync(1);
    }
}
