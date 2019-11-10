using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        PlayerPrefs.SetInt("restarted", 1);
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));

    }

    public void Exit()
    {
        Application.Quit();
    }
}
