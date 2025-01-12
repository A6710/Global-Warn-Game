using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton для сохранения объекта между сценами
    private AudioSource audioSource;

    private const string MusicStateKey = "MusicState"; // Ключ для хранения состояния музыки
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMusic();
            }
        }
    }
    void Awake()
    {
        // Проверяем, есть ли уже экземпляр MusicManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами

        audioSource = GetComponent<AudioSource>();

        // Восстанавливаем состояние музыки при запуске
        if (PlayerPrefs.HasKey(MusicStateKey))
        {
            bool isMusicOn = PlayerPrefs.GetInt(MusicStateKey) == 1;
            audioSource.mute = !isMusicOn;
        }
        else
        {
            // Если состояние музыки не было сохранено, включаем музыку по умолчанию
            PlayerPrefs.SetInt(MusicStateKey, 1);
            PlayerPrefs.Save();
        }
    }

    // Метод для переключения музыки
    public void ToggleMusic()
    {
        bool isMusicOn = !audioSource.mute;
        audioSource.mute = isMusicOn;

        // Сохраняем состояние
        PlayerPrefs.SetInt(MusicStateKey, isMusicOn ? 0 : 1);
        PlayerPrefs.Save();
    }

    // Метод для проверки текущего состояния музыки
    public bool IsMusicOn()
    {
        return !audioSource.mute;
    }
}

