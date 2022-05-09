using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSpawner : MonoBehaviour
{
	[SerializeField] GameObject pinPrefab;
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
		Spawn();
		Debug.Log("fire");
		/* score changes according to how big the balloon is, but "fire" button is triggered 
		multiple times, so score displayed is a reflection of how many pins were released */ 
	}
		
    }

	void Spawn(){
		Vector2 position = new Vector2(transform.position.x + 3, transform.position.y + 1);
		Instantiate(pinPrefab, position, Quaternion.identity);
	}
}
