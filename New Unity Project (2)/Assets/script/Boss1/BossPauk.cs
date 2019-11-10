using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPauk : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform MPGroundDataction;
    public float birth;
    public PaukHp pauk;
    void Start()
    {
        pauk = GetComponent<PaukHp>();
        birth = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (birth > 0)
        {
            birth -= Time.deltaTime;
        }
        else
        if (birth < 0 && pauk.hp>0)
        {
           

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(MPGroundDataction.position, Vector2.down, 2f);
            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }
}
