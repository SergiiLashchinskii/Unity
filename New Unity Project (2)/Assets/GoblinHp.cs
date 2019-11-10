using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHp : MonoBehaviour
{
 
    public int Goblinhp;
    public bool isEnemy = true;
    public float WizardDead;
    private Animator WizardAnim;


    // Use this for initialization
    void Start()
    {
        WizardDead = 1f;
       WizardAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Goblinhp <= 0 && WizardDead>0)
        {
            WizardDead -= Time.deltaTime;
            WizardAnim.SetBool("Dead", true);
            if(WizardDead<0)
            Destroy(gameObject);
        }
    }
    public void Damage(int damageCount)
    {
        Goblinhp -= damageCount;
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

