using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    Camera camera;
    AudioSource sound;
    void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	// Use this for initialization
	void Start () {
        
        sound = camera.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        sound.volume = GetComponent<Slider>().value;
	}
}
