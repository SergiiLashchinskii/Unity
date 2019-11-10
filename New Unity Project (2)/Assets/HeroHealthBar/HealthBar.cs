using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthBar : MonoBehaviour
{



    // Use this for initialization
    Transform bar;
    public float mobHP;
    private Animator anim;
    public TextMeshProUGUI dmgGotNumber;
    private Transform PlayerPosition;
    private TextMeshProUGUI toMove;
    private Rigidbody2D rb2d;

    private float timer = 3f;
    private bool deathFlag = false;

    public void Start()
    {

        bar = GameObject.FindGameObjectWithTag("Bar").transform;
        mobHP = bar.localScale.x;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    public void GetHit(float dmg)// 
    {
        var gm = Instantiate(dmgGotNumber, PlayerPosition.position, Quaternion.identity);
        gm.text = dmg.ToString();
        dmg += 0.01f;//Если это не сделать будет [ебучий] баг
        dmg /= 100f;//Т.к. хп от 0 до 1, дамаг надо делить на 100
        Vector3 HP = bar.localScale;
        HP.x = (HP.x - dmg);
        
        gm.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
        toMove = gm;
        rb2d = toMove.GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector3(2f, 2f, 0f), ForceMode2D.Impulse);
        if (HP.x <= 0f || HP.x > 1f)
        {
            HP.x = 0f;

            onDied();

        }

        bar.localScale = HP;
        mobHP = HP.x * 100f;
    }

    void Update()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        if (deathFlag == true)
        {
            
                SceneManager.LoadScene("Deathmenu");
        }
    }


    public void onDied()
    {
        Debug.Log("You died");
        anim.SetBool("isDead", true); //вызов анимации
        GameObject.FindGameObjectWithTag("Player").GetComponent<Main_char>().enabled = false; //отключение управления
        deathFlag = true;
    }

    

}
