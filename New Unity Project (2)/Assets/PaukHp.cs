
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaukHp : MonoBehaviour
{
    public int hp;
    private Animator anim;
    public bool isEnemy = true;
    public Slider healthbar;
    public float time;
    // Use this for initialization
    void Start()
    {
        time=1.2f;
        anim = GetComponent<Animator>();
        anim.SetBool("PaukDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = hp;
        if (hp <= 0 && time>0)
        {
            anim.SetBool("PaukDead", true);
            time -= Time.deltaTime;
            if(time<0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Shot shot = otherCollider.gameObject.GetComponent<Shot>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
    }
}
