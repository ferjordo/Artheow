using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour {
	public float maxSpeed = 10f;
	private Rigidbody2D rigi;
	bool facinRight = true;
	float move = 0.9f;
	/// SHOOT ///
	public Rigidbody2D stonePrefab;
    public Transform canion;
	bool shoot = false;
	 float timer = 0f;
     int waitingTime = 1;
	 /// 
	 bool grounded =   false;
	 bool IsStop = false;
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

	public float jumpForce = 200f;
	bool first =false, MoveD = true, MoveI = false;
	bool dobleJump = false;
	float same;
	bool alive= true;
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

		
		anim.SetBool ("Ground", grounded);
		anim.SetBool("IsStop", IsStop);
		anim.SetFloat ("vSpeed", rigi.velocity.y);

		// move = Input.GetAxis ("Horizontal");
		

		
	}


	//////////////////////////////////////////  COLLISION   ///////////////////////////////////////////

	void OnCollisionEnter2D(Collision2D coll)  {
		if (coll.gameObject.tag == "Ground"){
			grounded = true;
			dobleJump = false;
		}else if (coll.gameObject.tag=="Enemy")
		{
			Destroy(gameObject, 1);
			move = -0.9f;
			rigi.velocity = new Vector2 (0,0);
			rigi.AddForce(new Vector2 (-2, 150f));
			grounded=true;
			anim.SetBool("die", true);
			
 			
			}else if (coll.gameObject.tag=="municion")
			{		
				shoot = true;
				anim.SetBool("Shoot", true);

			} else if (coll.gameObject.tag=="Pared")
			{
				IsStop = true;
			}	

	}
	void OnCollisionStay2D ( Collision2D coll){
				
	}
	void OnCollisionExit2D(Collision2D coll)  {
		if (coll.gameObject.tag == "Ground"){
			grounded = false;

		}if (coll.gameObject.tag=="Pared")
		{
			IsStop = false;
		}	


	}
	void Update(){
 	
	rigi.velocity = new Vector2 (move * maxSpeed, rigi.velocity.y);
	
	if (same.Equals( transform.position.x) && first){
		//Debug.Log("Esta quieto..  ");
		//rigi.velocity= new Vector2(0, 0);
		//transform.position = new Vector2 (transform.position.x, transform.position.y);
		//Debug.Log("Esta quieto.. ");
		if(MoveI){
			jumpRigth = true ;
			jumpLeft= false;
		
		}else if(MoveD){
			jumpLeft  = true;
			jumpRigth =  false;
			
		}
		
	}else if (same > transform.position.x) {
				//Debug.Log("En movimiento... ");
			
				first=true;
				same=transform.position.x;
				 MoveD = true;
				 MoveI = false;
	}else if ( same < transform.position.x){
				//Debug.Log("En movimiento... ");
				first=true;
				same=transform.position.x;
				MoveD = false;
				MoveI = true;
	}
	if (shoot && grounded){
			timer += Time.deltaTime;
     		if((timer > waitingTime) && grounded){
				 if(jumpLeft){
		
				Rigidbody2D stoneInstance;
				stoneInstance = Instantiate(stonePrefab, canion.position, canion.rotation) as Rigidbody2D;
				stoneInstance.AddForce(new Vector2 (-900, 0));
				timer =0f;
		}else if(jumpRigth){
			
				Rigidbody2D stoneInstance;
				stoneInstance = Instantiate(stonePrefab, canion.position, canion.rotation) as Rigidbody2D;
				stoneInstance.AddForce(new Vector2 (900, 0));
				timer =0f;
		}
	 		}
		}


	}
	
	void  OnMouseDown() {
		
       if(( jumpRigth)  ){
		   if(!dobleJump || grounded || IsStop){
			anim.SetBool ("Ground", false);
			move = 0.9f;
			rigi.AddForce (new Vector2 (0, jumpForce));
			theScale.x =Mathf.Abs( transform.localScale.x);
			transform.localScale = theScale;
		   }
		}else if ((jumpLeft) ){
			if(!dobleJump|| grounded || IsStop  ){
			anim.SetBool ("Ground", false);
			//Debug.Log("Saltar para Izquierda");
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
