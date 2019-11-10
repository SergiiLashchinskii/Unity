using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private Vector3 start;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        start = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall() // Or DropPlatform ()
    {
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
    }

    void Respawn()
    {
        GetComponent<Collider2D>().isTrigger = false;
        transform.position = start;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
    }
}