using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Primeravez : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("first")==1){
			SceneManager.LoadScene("menu", LoadSceneMode.Single);
		}else{
		PlayerPrefs.SetInt("first", 1 );
		
		}		
	}
	
}
