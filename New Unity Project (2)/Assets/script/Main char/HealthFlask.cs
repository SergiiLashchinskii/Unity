using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlask : MonoBehaviour {
    HealthBar HPBarScript;
    public float health = 15f;
    void Awake()
    {
      HPBarScript = FindObjectOfType<HealthBar>();
    }
   void OnTriggerEnter2D(Collider2D Col)
    {
      //  HPBarScript.GetHeal(health);
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
