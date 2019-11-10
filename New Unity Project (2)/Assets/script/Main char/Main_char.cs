using System.Collections;
using UnityEngine;

using TMPro;
//mass  1.33
//gravity 1.96


public class Main_char : MonoBehaviour
{
    GameObject checkpointText;

    private Animator anim;
    // движение
    public float maxSpeed = 40f; // максимальная скорость персонажа
    private bool facingRight = true;
    public bool grounded = false; // если true -то на земле
    //прыжок,падение
    public Transform groundCheck;
    private float GroundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;
    public Transform bar;
    //Скрипт ХП бара
    public HealthBar HPBarScript;
    private Rigidbody2D rb2d;

    public float checkPointTextTime = 2.5f;

    //-------Нуязвимость---------//
    private bool ableToGetDmg = true;
    float timeRemaining = 1f; //Время неуязвимости

    // Use this for initialization


    private void Start()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bar = GameObject.FindGameObjectWithTag("Healthbar").transform;

        //Это чтобы мы мгли юзать функции которые находятся в другом скрипте
        HPBarScript = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<HealthBar>();

        anim.SetBool("isDead", false);
        anim.SetBool("Attack", false);
    }

    private void FixedUpdate()
    {
        anim.SetBool("Ground", grounded);
        grounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);//генерация,радиус,с чем сталкиевается.
        //if (!grounded) return;                                                            // игрок не упавляет персонажем после прыжка.
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);                   //скорость прыжка.


        float move = Input.GetAxis("Horizontal"); //направление
        //скорость 
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else
            if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        
        if (ableToGetDmg == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.6f);

            
            if (timeRemaining > 0)
            {
                Debug.Log("w8 +" + timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                ableToGetDmg = true;
                timeRemaining = 3.5f;
                
            }
        }else GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);


        //Если что-то случилось то нанести домог))0)
        if (Input.GetKeyDown(KeyCode.X))
        {
            HPBarScript.GetHit(10f);
        }


        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Ran_Attack", false);
        }
        if (Input.GetButtonDown("Fire1") && GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            anim.SetBool("Ran_Attack", true);
        }


    }
  

    public void Flip() //анимация поворота влево
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("enemy"))
        {
            if (ableToGetDmg) HPBarScript.GetHit(15f);

            ableToGetDmg = false;
        }

        if (otherCollider.CompareTag("boss"))
        {
            if (ableToGetDmg) HPBarScript.GetHit(30f);

            ableToGetDmg = false;
        }

        if (otherCollider.CompareTag("down"))
        {
            if (ableToGetDmg) HPBarScript.GetHit(100f);

            ableToGetDmg = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) // просто кошмарное решение,зато работает
    {
        if (col.transform.tag == "enemy")
        {
            if(ableToGetDmg) HPBarScript.GetHit(15f);

            ableToGetDmg = false;

        }

        /*  либо так
          int cout=0;
         if (col.transform.tag=="enemy")
        {
            HPBarScript.GetHit(10f);
           count++;
           if(count==10)
                anim.SetBool("isDead", true);// вызов анимации
                 GetComponent<Main_char>().enabled = false; //отключение управления
            
        }
        */

    }



    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {

        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);   //<----------------------
            rb2d.AddForce(new Vector3(knockBackDir.x * -100, knockBackDir.y * knockBackPwr, transform.position.z));


        }
        yield return 0;

    }
    public IEnumerator Batut(float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {

        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);   //<----------------------
            rb2d.AddForce(new Vector3(knockBackDir.x * 1, knockBackDir.y * knockBackPwr, transform.position.z));

        }
        yield return 0;

    }
}


