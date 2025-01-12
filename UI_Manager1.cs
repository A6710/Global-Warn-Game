using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public AudioClip clickSound; // ���� ��� �����
    private AudioSource audioSource;
    public GameObject PanAboutPop;
    public GameObject[] obj;
    bool is_on = false;

    void Start()
    {
        // ��������� ��������� AudioSource, ���� ��� ���
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.playOnAwake = false; // ����� ���� �� ����� ��� ������
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        // ���������, ��� �� ��������� ����
        if (Input.GetMouseButtonDown(0)) // ���
        {
            audioSource.Play();
        }
    }
    public void SartS()
    {
        StartCoroutine(WaitS());
    }
    public void mm()
    {
        SceneManager.LoadScene(0);
    }
    public void About()
    {
        if (is_on)
        {
            PanAboutPop.SetActive(false);
            is_on = false;
        } else
        {
            PanAboutPop.SetActive(true);
            is_on = true;
        }
    }
    public void Exitt()
    {
        Application.Quit();
    }

    public void GHKbutton(int indx)
    {
        obj[8].SetActive(false);
        obj[indx].SetActive(true);
        StartCoroutine(WaitSe());
    }

    IEnumerator WaitS()
    {
        obj[0].SetActive(true);
        obj[1].SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitSe()
    {
        yield return new WaitForSeconds(0.1f);
        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
    }
}
