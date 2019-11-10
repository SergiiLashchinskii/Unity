using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bochka : MonoBehaviour
{
    public int hp;
    private Animator Barrelanim;
    private Transform player;
    public float range;
    private Vector2 target;
    public float Tboom;
    float direction = -1f;
    public float speed;
    public Rigidbody2D rb;
    public float boom;
    public HealthBar HPBarScript;
    // Use this for initialization
    void Start()
    {
        HPBarScript = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<HealthBar>();
        Barrelanim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Barrelanim.SetBool("isDead", false);
        boom = 1f;
        Tboom = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) < range)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            if (Tboom > 0)
            {
                
                Tboom -= Time.deltaTime;
                if (Tboom < 0)
                {
                    speed = 0;
                    Barrelanim.SetBool("isDead", true);
                    GetComponent<CircleCollider2D>().isTrigger = true;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
                Destroy(gameObject, 5);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col) // просто кошмарное решение,зато работает
    {
        if (col.transform.tag == "Player")
        {
        
            if (boom > 0)
            {
                GetComponent<CircleCollider2D>().isTrigger = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                speed = 0;
                Barrelanim.SetBool("isDead", true);
              boom -= Time.deltaTime;
                if (boom < 0)
                {
                    
                    Destroy(gameObject);
                }

                Debug.Log("Boom");
            }
        }
    }
}
