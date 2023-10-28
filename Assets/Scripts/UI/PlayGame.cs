using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.instance.PlayClickSound();
        SceneManager.LoadSceneAsync(1);
    }
}
