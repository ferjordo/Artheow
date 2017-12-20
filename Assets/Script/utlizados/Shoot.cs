using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public Rigidbody2D stonePrefab;
    public Transform canion;
	bool shoot = false;
	 float timer = 0f;
     int waitingTime = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (shoot){
			timer += Time.deltaTime;
     		if(timer > waitingTime){
				Rigidbody2D stoneInstance;
				stoneInstance = Instantiate(stonePrefab, canion.position, canion.rotation) as Rigidbody2D;
				stoneInstance.AddForce(new Vector2 (900, 0));
				timer =0f;
	 		}
		}
	}
	void OnCollisionEnter2D(Collision2D coll)  {
		if (coll.gameObject.tag == "municion"){
			shoot = true;
		
		}

	}
}
