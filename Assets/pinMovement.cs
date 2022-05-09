using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinMovement : MonoBehaviour
{
	Rigidbody2D rigid;
	int speed;
	
    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
		rigid = GetComponent<Rigidbody2D>();
	speed = 10;   
    }

	void FixedUpdate()
    {
        rigid.velocity = new Vector2(speed,0);
    }
}
