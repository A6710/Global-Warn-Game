using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Buttactive : MonoBehaviour
{
    public Image imageComponent;
    public UI_Manager manager;
    public int buttonindx4_7;

    public void rrr()
    {                   
        manager.GHKbutton(buttonindx4_7);
        imageComponent.enabled = true;
    }
}
    
