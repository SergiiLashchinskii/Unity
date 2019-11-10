using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 20f; // скорость пули
    public Rigidbody2D rb;
    public Main_char main;
    
    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3); // уничтожение пули спустя 3сек

        if(main.transform.localScale.x<0) // пуля меняется по иксу когда стреляют вправо
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
	
}
