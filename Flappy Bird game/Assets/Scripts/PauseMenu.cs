using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton;

    public void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0;
        PauseButton.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
    }
}
