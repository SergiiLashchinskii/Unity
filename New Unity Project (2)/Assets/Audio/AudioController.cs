using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {


    AudioSource AS;
    Main_char ground;
    bool lastGround = true;

    void Awake()
    {
        AS = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        ground = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_char>();
        

    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
        if (ground.grounded == lastGround && ground.grounded == true && Input.GetAxis("Horizontal") != 0)
        {
            AS.Play();
            lastGround = !lastGround;
        }

        if (ground.grounded == false || Input.GetAxis("Horizontal") == 0)
        {
            AS.Stop();
            lastGround = true;
        }

    }
}
