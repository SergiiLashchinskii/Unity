using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	// Use this for initialization



    void Awake()
    {
      

    }
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetFloat("x",this.transform.position.x);
            PlayerPrefs.SetFloat("y",this.transform.position.y);
        }
    }
}
