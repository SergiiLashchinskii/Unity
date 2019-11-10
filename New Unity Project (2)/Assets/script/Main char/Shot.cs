using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour { //скрипт для получения урона от пули мобом, см. MobPatrol
    public int damage=1;

    public bool isEnemyShot = false;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
       

        
    }
}
