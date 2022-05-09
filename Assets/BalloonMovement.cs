using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class BalloonMovement : MonoBehaviour
{

	[SerializeField] GameObject controller;
	GameObject seeker;

	int actualScore;
	int speed;
	int currentLevel;

	Vector3 currentVelocity;
	Vector3 desiredVelocity;
	Vector3 steeringVelocity;
	Vector3 changeScale;
	
	float score;
	float maxVelocity;
	float maxDistance;
	float maxForce;

	Rigidbody2D rigid;
	bool isGoingUp;
	AudioSource popSound;
	Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
     	if(rigid == null)
		rigid = GetComponent<Rigidbody2D>(); 
	isGoingUp = true;
	if(popSound == null)
		popSound = GetComponent<AudioSource>();

	changeScale = new Vector3(0.05f,0.05f,0.05f);	// how much the balloon will increase in size
	InvokeRepeating("ChangeSize", 5f, 0.05f);	// start growing after five seconds, called every .05 seconds
	currentLevel = SceneManager.GetActiveScene().buildIndex;

	if(currentLevel == 1){
		speed = 3;  
	}else if(currentLevel == 2){
		speed = 5;
	}

	animator = GetComponent<Animator>();
	
	maxDistance = 10;
	maxVelocity = 50;
	maxForce = 1f;
	seeker = GameObject.Find("Spongebob");
    }

	void FixedUpdate()
    {

	if(currentLevel < 3){
		rigid.velocity = new Vector2(0,speed);
		if(transform.position.y > 3.27 && isGoingUp || transform.position.y < -3.67 && !isGoingUp)
			ChangeSpeed();	
	}else{
		if(Vector3.Distance(transform.position, seeker.transform.position) < maxDistance){
			desiredVelocity = (transform.position - seeker.transform.position).normalized;
			desiredVelocity *= maxVelocity;
			steeringVelocity = desiredVelocity - currentVelocity;
			steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, maxForce);
			currentVelocity = steeringVelocity;
			currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxVelocity);
			transform.position += currentVelocity * Time.deltaTime;
		}
	}  
    }

	void ChangeSpeed(){
		speed = -speed;
		isGoingUp = !isGoingUp;
	}

	void OnTriggerEnter2D(Collider2D other)
    {
	AudioSource.PlayClipAtPoint(popSound.clip,transform.position);
	score = 60/transform.localScale.x;
	actualScore = Mathf.RoundToInt(score);
	Debug.Log(score);	
	/* score changes according to how big the balloon is, but "fire" button is triggered 
multiple times, so score displayed is a reflection of how many pins were released */ 
		
	controller.GetComponent<Scorekeeper>().UpdateScore(actualScore);
	animator.SetTrigger("popped");
	StartCoroutine(WaitAndDestroy());	
    }

	// wait for balloon popping animation to finish, then destroy the balloon and load next scene
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(0.8f);
		Destroy(gameObject);
		SceneManager.LoadScene(currentLevel + 1);
	}

	// reload scene if balloon gets too big, otherwise keep growing
	void ChangeSize(){
		if(transform.localScale.x > 12f){
			SceneManager.LoadScene(currentLevel);
		}else{
			transform.localScale += changeScale;
		}
	}
}
