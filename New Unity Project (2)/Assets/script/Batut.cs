using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batut : MonoBehaviour
{
    private Main_char player;
    public int knockbackPower;


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_char>();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(player.Batut(0.1f, knockbackPower, player.transform.position));




        }
    }
}


// Update is called once per frame
