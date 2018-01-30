using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountStar : MonoBehaviour {

	public GameObject cor1;
	public GameObject cor2 ;
	public GameObject cor3;
	public GameObject cartel1;
	public GameObject cartel2;
	int stars;

	// Use this for initialization
	void Start () {
		stars =  PlayerPrefs.GetInt("star");
		Debug.Log ("stars: "+stars);
		
		cor1.SetActive(false);
		cor2.SetActive(false);
		cor3.SetActive(false);
		cartel1.SetActive(false);
		cartel2.SetActive(false);

		if(stars==1){
		cor1.SetActive(true);
		cartel1.SetActive(true);
		}else if (stars==2){
		cor2.SetActive(true);
		cartel1.SetActive(true);
		}else if (stars==3){
		cartel2.SetActive(true);
		cor3.SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
