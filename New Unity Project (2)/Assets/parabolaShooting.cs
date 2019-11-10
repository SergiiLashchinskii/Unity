using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabolaShooting : MonoBehaviour {

    private Transform pint;
    public float range;
    private float TimeBtwShots;
    public float StartTimeBtwShots;
    public GameObject projectile;
    // Use this for initialization
    void Start()
    {
        pint = GameObject.FindGameObjectWithTag("pint").transform;
        TimeBtwShots = StartTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pint.position) < range)
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

