using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)  {
		 if (coll.gameObject.tag=="Enemy") 
		{
			
		SceneManager.LoadScene("Nivel1", LoadSceneMode.Single);
			
		}
	}
}
