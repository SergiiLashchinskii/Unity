using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCheckpoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteAll()
    {
        PlayerPrefs.SetInt("restarted", 0);
    }
}
