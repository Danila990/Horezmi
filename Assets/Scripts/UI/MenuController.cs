using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] _allMenu;

    public void OpenMenu(GameObject needMenu)
    {
        foreach (GameObject menu in _allMenu)
            menu.SetActive(false);

        needMenu.SetActive(true);
    }
}
