using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

  
    public Transform ShotPrefab; 
    public Transform firePoint; // точка стрельбы
    private bool cooldown = false;      //
    public float shotCooldown;          // кулдаун
    private float shootingRate = 0.5f;   //
    private bool time = false;           //
    // Use this for initialization
    void Start () {

        shotCooldown =0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
        else time = false;
        
            if (Input.GetButtonDown("Fire1") && time==false)
            {
                Attack();
                shotCooldown = shootingRate;
                time = true;
            
        }



    }
    public void Attack() // полет пули
    {
       
      Instantiate(ShotPrefab, firePoint.position, firePoint.rotation);
    }

  
}
