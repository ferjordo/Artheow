using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loading : MonoBehaviour {
float timer= 0;
	
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		if(timer>3f){
					SceneManager.LoadScene(1, LoadSceneMode.Single);
					Debug.Log(" CAmbair escena");


		}
	}
}
