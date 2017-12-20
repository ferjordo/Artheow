using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	
void Awake(){
	//Destroy(gameObject, 2);
}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll)  {
		if (coll.gameObject.tag == "Enemy"){
		//Debug.Log ("Eliminar");
		Destroy(gameObject);
		}else if (coll.gameObject.tag == "Ground"){
		//Debug.Log ("Eliminar");
		Destroy(gameObject);
		} 

	}
}
