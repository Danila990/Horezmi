using UnityEngine;
using UnityEngine.Localization.Settings;
using YG;

public class LocalizationSetup : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL
        if (LocalizationSettings.InitializationOperation.IsDone)
        {
            Debug.Log($"Start language set to {YandexGame.EnvironmentData.language} after localization initialized");
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(YandexGame.savesData.language);
        }
        else
        {
            LocalizationSettings.InitializationOperation.Completed += x =>
            {
                Debug.Log($"Start language set to {YandexGame.EnvironmentData.language} before localization initialized");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(YandexGame.savesData.language);
            };
        }
#endif


        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(YandexGame.savesData.language);
    }
}
