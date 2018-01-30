using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
float timer= 0;

	 public int scene; 
	
	
	// Update is called once per frame
	void Update () {
		 timer+= Time.deltaTime;
		if(timer>8f){
					SceneManager.LoadScene(scene, LoadSceneMode.Single);
					Debug.Log(" Cambair escena");


		}
	}
	
	
}
