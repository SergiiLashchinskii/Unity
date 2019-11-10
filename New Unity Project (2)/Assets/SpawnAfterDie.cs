using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterDie : MonoBehaviour {

	// Use this for initialization

    Transform mChar;

    void Awake()
    {
        mChar = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Start () {

        if (PlayerPrefs.GetInt("restarted") == 1)
        {
            Vector3 xy = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));

            mChar.position = xy;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
