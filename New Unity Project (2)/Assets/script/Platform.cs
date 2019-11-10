using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour { //скрипт для слезания игрока с платформы
    private PlatformEffector2D effector;
    public float WaitTime;
	// Use this for initialization
	void Start () {
        effector = GetComponent<PlatformEffector2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.S))
        {
            WaitTime = 0.5f;
        }
		if(Input.GetKey(KeyCode.S)) //сколько секунд надо держать кнопку 
        {
           if(WaitTime<=0)
            {
                effector.rotationalOffset = 180f;
                WaitTime = 0.5f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
	}
}
