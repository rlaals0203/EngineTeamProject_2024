using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Forest");
    }

    public void SettingPanel()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
