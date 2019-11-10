using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
    private Main_char Main_char;
    public int knockbackPowerInEditor;


    // Use this for initialization
    void Start () {

        Main_char = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_char>();
        
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            StartCoroutine(Main_char.KnockBack(0.02f, knockbackPowerInEditor, Main_char.transform.position));




        }
    }
    }


    // Update is called once per frame
  