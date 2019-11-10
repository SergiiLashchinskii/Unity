using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    GameObject mainMenu;
    GameObject optionsMenu;

    void Awake()
    {
        mainMenu = GameObject.FindGameObjectWithTag("PausedMenu");
        DontDestroyOnLoad(transform.gameObject);
        optionsMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
    }

    void Start () {


        optionsMenu.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        mainMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
    }

    public void OpenMainMenu()
    {
        optionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void CompleteRestart()
    {
        PlayerPrefs.SetInt("restarted", 0);
        SceneManager.LoadScene("1думуд");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

	// Use this for initialization



}
