using UnityEngine;
using System.Collections;

public class CamaraController: MonoBehaviour 
{
	public Transform Target;
 
	public Vector2
	Margin,
	Smoothing;

	//public BoxCollider2D Bounds;

	private Vector3
	_min,
	_max;

	//public bool isFollowing { get; set; }

	public void Start()
	{
		/*_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		isFollowing = true;*/
	}

 
	public void Update()
	{
	
		var x = Target.transform.position.x;
		var y = Target.transform.position.y;
		transform.position = new Vector3(x, y, transform.position.z);


	}
}
