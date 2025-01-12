using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotat : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(WaitSe());
    }
    IEnumerator WaitSe()
    {
        yield return new WaitForSeconds(15.0f);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            // Загружаем следующую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Если следующей сцены нет, загружаем первую сцену
            SceneManager.LoadScene(0);
        }
    }
}
