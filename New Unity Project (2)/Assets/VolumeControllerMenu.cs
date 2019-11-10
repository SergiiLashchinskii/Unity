using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControllerMenu : MonoBehaviour {

	// Use this for initialization
    AudioSource AS;
    Slider slider;

	void Start () {
        AS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        AS.volume = slider.value;
	}
}
