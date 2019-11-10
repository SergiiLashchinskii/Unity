using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHp : MonoBehaviour {

    public int Slimehp;
    public bool isEnemy = true;
    public float SlimeDead;
    private Animator SlimeAnim;
    // Use this for initialization
    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
        SlimeDead = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Slimehp <= 0 && SlimeDead > 0)
        {
            SlimeDead -= Time.deltaTime;
            SlimeAnim.SetBool("SlimeDead", true);
            if (SlimeDead < 0)
                Destroy(gameObject);
        }
    }
    public void Damage(int damageCount)
    {
        Slimehp -= damageCount;
      
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
