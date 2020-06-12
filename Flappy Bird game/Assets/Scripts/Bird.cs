using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bird : MonoBehaviour
{
	private bool _isDead = false;
	private Rigidbody2D _rb2d;
	private Animator _anim;
    int Skinnumber;

    public float upForce = 200f;
    public CameraShake cameraShake;
    public AnimatorOverrideController yellow;
    public AnimatorOverrideController black;

    void Start ()
	{
        Skinnumber = PlayerPrefs.GetInt("Skin");
		_rb2d = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
        if (Skinnumber == 1)
        {
            GetComponent<Animator>().runtimeAnimatorController = yellow as RuntimeAnimatorController;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = black as RuntimeAnimatorController;
        }


	}

    void Update()
    {
        if (GameObject.FindWithTag("PauseMenu")) { _rb2d.velocity = Vector2.zero; }
        else
        {
            if (_isDead == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null) 
                        return;
                        {
                            _rb2d.velocity = Vector2.zero;
                            _rb2d.AddForce(new Vector2(0, upForce));
                            _anim.SetTrigger("Flap");
                        }
                    }
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


        if (col.collider.tag == "Ground")
		{
			AudioManager.instance.Play("hitGround");
		}
		else if(col.collider.tag == "Columns")
		{
			AudioManager.instance.Play("hitColumn");
		}

	}
}
