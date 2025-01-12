using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton ��� ���������� ������� ����� �������
    private AudioSource audioSource;

    private const string MusicStateKey = "MusicState"; // ���� ��� �������� ��������� ������
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
        // ���������, ���� �� ��� ��������� MusicManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������

        audioSource = GetComponent<AudioSource>();

        // ��������������� ��������� ������ ��� �������
        if (PlayerPrefs.HasKey(MusicStateKey))
        {
            bool isMusicOn = PlayerPrefs.GetInt(MusicStateKey) == 1;
            audioSource.mute = !isMusicOn;
        }
        else
        {
            // ���� ��������� ������ �� ���� ���������, �������� ������ �� ���������
            PlayerPrefs.SetInt(MusicStateKey, 1);
            PlayerPrefs.Save();
        }
    }

    // ����� ��� ������������ ������
    public void ToggleMusic()
    {
        bool isMusicOn = !audioSource.mute;
        audioSource.mute = isMusicOn;

        // ��������� ���������
        PlayerPrefs.SetInt(MusicStateKey, isMusicOn ? 0 : 1);
        PlayerPrefs.Save();
    }

    // ����� ��� �������� �������� ��������� ������
    public bool IsMusicOn()
    {
        return !audioSource.mute;
    }
}

