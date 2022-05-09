using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	float move;
	float moveY;

	int speed;
	bool isFacingRight;
	Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
     	if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();   
	speed=10;
	isFacingRight=true;
    }

    // Update is called once per frame
    void Update()
    {
        move= Input.GetAxis("Horizontal");
	moveY= Input.GetAxis("Vertical");
    }

	void FixedUpdate(){
		rigid.velocity= new Vector2(move * speed, moveY * speed);
		if (move < 0 && isFacingRight || move > 0 && !isFacingRight)
            		Flip();
	}

	void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
