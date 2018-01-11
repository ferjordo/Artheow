using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour {

void Awake(){
	//Destroy(gameObject, 2);
}
	// Use this for initialization
	void Start () {
	//TxTmunicion.text= "Puntaje ";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll)  {
		if ((coll.gameObject.tag == "Enemy") ||(coll.gameObject.tag == "item"))  {
		
		Destroy(gameObject);
		}else if (coll.gameObject.tag == "Ground"){
		//TxTmunicion.text="Score: "+municion + 10;
		Destroy(gameObject);
		} 

	}
}
