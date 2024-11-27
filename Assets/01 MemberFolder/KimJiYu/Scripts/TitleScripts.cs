using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    public void StartGame()
    {
        if(!SettingWindow.Instance._isMoving)
            SceneManager.LoadScene("Forest");
    }

    public void SettingPanel()
    {

    }

    public void ExitGame()
    {
        if (!SettingWindow.Instance._isMoving)
            Application.Quit();
    }
}
