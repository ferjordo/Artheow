using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEarth : MonoBehaviour {
Rigidbody2D rigidbody;
float waitingTime2 = 6;
float timer = 0f;
float move = -2;
	  Vector3 theScale ;



	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		theScale = transform.localScale;


	}
	
	// Update is called once per frame
	void Update () {
			rigidbody.velocity = new Vector2 ( move * 0.9f, rigidbody.velocity.y);
			timer+= Time.deltaTime;
			if(timer >waitingTime2){
			move = move *-1;

			theScale.x = transform.localScale.x * -1;
			transform.localScale = theScale;

			timer=0;
			}

	}
		void OnCollisionEnter2D(Collision2D coll)  {
			if (coll.gameObject.tag == "piedra"){
			//Debug.Log ("Eliminar");
			Destroy(gameObject);
			}
		}
}
