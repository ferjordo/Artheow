using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			foreach (Touch touch in Input.touches) 
 					{
						Debug.Log("Dedo "+touch.fingerId);
						Debug.Log("Posicion +"+touch.position);
						Debug.Log("\nPosición respecto al ultimo frame"+touch.deltaPosition);
						Debug.Log("\nfase en la que se encuentra el dedo "+touch.phase);
 					}
	}
    

}
