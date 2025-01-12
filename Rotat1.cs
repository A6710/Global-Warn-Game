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
            // ��������� ��������� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // ���� ��������� ����� ���, ��������� ������ �����
            SceneManager.LoadScene(0);
        }
    }
}
