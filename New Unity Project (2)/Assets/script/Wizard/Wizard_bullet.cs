using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_bullet : MonoBehaviour {
    public float speed;
    private Transform player;
    private Vector2 target;
    public HealthBar HP;
    public Rigidbody2D rb;
    public Main_char main;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y); 
        rb.velocity = transform.right * -speed;
        Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {
       
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            HP.GetHit(15f);
        }
    }
    
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
