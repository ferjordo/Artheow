using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiFloat : MonoBehaviour {

	Transform transform;
	private Rigidbody2D rigi;

	public Rigidbody2D stonePrefab;
    public Transform canion;
     int waitingTime = 3;
	 float timer = 0f;
	 float y = 0f;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		rigi = GetComponent<Rigidbody2D>();
		y = transform.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.y < y-6f) {
		        
		rigi.AddForce(new Vector2 (0, 300));
	}
		timer += Time.deltaTime;
		if(timer > waitingTime){
					Rigidbody2D stoneInstance;
						stoneInstance = Instantiate(stonePrefab, canion.position, canion.rotation) as Rigidbody2D;
						stoneInstance.AddForce(new Vector2 (-1000, 0));
						timer =0f;
			
			}
	}

	void OnCollisionEnter2D(Collision2D coll)  {
		if (coll.gameObject.tag == "municion"){
		//Debug.Log ("Eliminar");
		Destroy(gameObject);
		}

	}
}
