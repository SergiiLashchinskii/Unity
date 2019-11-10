using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            PlayerPrefs.SetInt("restarted", 0);
            PlayerPrefs.SetString("level", "level2");
            SceneManager.LoadScene("level2");
        }
    }
}
