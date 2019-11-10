using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    GameObject pauseMenu;
    Main_char mchar;
    WeaponScript wscript;
    GameObject optMenu;

    void Awake()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PausedMenu");
        optMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
        mchar = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_char>();
        wscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponScript>();
        DontDestroyOnLoad(transform.gameObject);


    }

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
	}

    public void OpenPause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        mchar.enabled = !mchar.enabled;
        wscript.enabled = !wscript.enabled;
        Time.timeScale = pauseMenu.activeSelf == false ? 1 : 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPause();
            if (optMenu.activeSelf == true)
                optMenu.SetActive(false);

            if (optMenu.activeSelf == false &&
               pauseMenu.activeSelf == false)
            {
                mchar.enabled = true;
                wscript.enabled = true;
                Time.timeScale = 1;
            }
        }
	}
}
