using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vizard_Shoot : MonoBehaviour
{
    private Transform player;
    public float range;
    private float TimeBtwShots;
    public float StartTimeBtwShots;
    public GameObject projectile;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBtwShots = StartTimeBtwShots;


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {



            if (TimeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                TimeBtwShots = StartTimeBtwShots;
            }
            else
            {
                TimeBtwShots -= Time.deltaTime;
            }
        }
    }
}