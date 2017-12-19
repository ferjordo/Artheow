using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour {
	public float maxSpeed = 10f;
	private Rigidbody2D rigi;
	
	bool facinRight = true;
	float move = 0.9f;

	/// <summary>
	/// The grounded in the varible to make the player jump.
	/// </summary> 
	bool grounded =   false;
	bool jumpLeft = false;
	bool jumpRigth = true;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	//public Rigidbody2D Follow;

	public bool isTrigger; 

	/// <summary>
	/// The jump force.
	/// </summary>

	public float jumpForce = 500f;
	bool first =false, MoveD = true, MoveI = false;
	bool dobleJump = false;
	float same;
	Animator anim;
	Collider2D collider;
	Transform transform;
	  Vector3 theScale ;
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D> ();
		//Follow = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D>();
		transform = GetComponent<Transform>();
	same =  transform.position.x - 1;
		 theScale = transform.localScale;
		
	}
	
	void FixedUpdate () {

		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//Debug.Log (grounded);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigi.velocity.y);

		// move = Input.GetAxis ("Horizontal");

		
	}


	//////////////////////////////////////////  COLLISION   ///////////////////////////////////////////

	void OnCollisionEnter2D(Collision2D coll)  {
		if (coll.gameObject.tag == "Ground"){
			grounded = true;
			dobleJump = false;
		//	Debug.Log ("ground true");
		}else if (coll.gameObject.tag=="Enemy")
		{
			grounded=true;
			anim.SetBool("die", true);
 			
			}else if (coll.gameObject.tag=="municion")
		{
				anim.SetBool("shoot", true);
		}

	}
	void OnCollisionStay2D ( Collision2D coll){
		if (coll.gameObject.tag=="Pared")
		{
			

		}else if (coll.gameObject.tag=="Pared")
		{
			
		}			
	}
	void OnCollisionExit2D(Collision2D coll)  {
		if (coll.gameObject.tag == "Ground"){
			grounded = false;

			//Debug.Log ("ground false");
		}

	}
	void Update(){
 	
	rigi.velocity = new Vector2 (move * maxSpeed, rigi.velocity.y);
	
	if (same.Equals( transform.position.x) && first){
		//Debug.Log("Esta quieto..  ");
		
		
		if(MoveI){
			jumpRigth = true ;
			jumpLeft= false;
		
		}else if(MoveD){
			jumpLeft  = true;
			jumpRigth =  false;
			
		}
		
	}else if (same > transform.position.x) {
		//Debug.Log(same+ " > "+transform.position.x);
				first=true;
				same=transform.position.x;
				 MoveD = true;
				 MoveI = false;
	}else if ( same < transform.position.x){
		//Debug.Log(same+ " > "+transform.position.x);
				first=true;
				same=transform.position.x;
				MoveD = false;
				MoveI = true;
	}


	}
	
	void  OnMouseDown() {
		
       if(( jumpRigth)  ){
		   if(!dobleJump || grounded){
			Debug.Log ("Saltar para derecha");
			anim.SetBool ("Ground", false);
			move = 0.9f;
			rigi.AddForce (new Vector2 (0, jumpForce));
			theScale.x =Mathf.Abs( transform.localScale.x);
			transform.localScale = theScale;
		   }
		}else if ((jumpLeft) ){
			if(!dobleJump|| grounded  ){
			anim.SetBool ("Ground", false);
			Debug.Log("Saltar para Izquierda");
			move = -0.9f;
			rigi.AddForce(new Vector2 (-5, jumpForce));
			theScale.x = -Mathf.Abs(transform.localScale.x);
			transform.localScale = theScale;
			}
		}
  if (!dobleJump && !grounded)
        dobleJump = true;
    }
}
