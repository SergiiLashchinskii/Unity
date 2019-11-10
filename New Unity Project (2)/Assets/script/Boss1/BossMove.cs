using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
    private bool facingRight = true;
    public float speed;
    private bool movingRight = true;
    public Transform BossGroundDataction;
    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(BossGroundDataction.position, Vector2.down, 2f);
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
     
    void FixedUpdate()
    {
        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else
          if (speed < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip() //анимация поворота влево
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

    }
}
