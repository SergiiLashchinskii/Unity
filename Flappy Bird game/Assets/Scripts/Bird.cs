using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	private bool _isDead = false;
	private Rigidbody2D _rb2d;
	private Animator _anim;
	
	public float upForce = 200f;
	public CameraShake cameraShake;
	
	void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(_isDead == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				_rb2d.velocity = Vector2.zero; 
				_rb2d.AddForce(new Vector2(0, upForce));
				_anim.SetTrigger("Flap");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		_rb2d.velocity = Vector2.zero;
		_isDead = true;
		_anim.SetTrigger("Die");

		GameControl.instance.BirdDied();

		StartCoroutine(cameraShake.Shake(.15f, .14f)); 

		if(col.collider.tag == "Ground")
		{
			AudioManager.instance.Play("hitGround");
		}
		else if(col.collider.tag == "Columns")
		{
			AudioManager.instance.Play("hitColumn");
		}

	}
}
