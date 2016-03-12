using UnityEngine;
using System.Collections;

public class PlaerController : MonoBehaviour {
	
	public float moveSpeed = 5;
	private float moveVelocity;
	public float jumpHeight = 15;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded)
			doubleJumped = false;

		anim.SetBool ("grounded", grounded);

		if (Input.GetKeyDown (KeyCode.W) && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			
		}
		if (Input.GetKeyDown (KeyCode.W) && !doubleJumped && !grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			doubleJumped = true;
		}	

		moveVelocity = 0f;

		if (Input.GetKey (KeyCode.D)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector3 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}	
		if (Input.GetKey (KeyCode.A)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector3 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		anim.SetFloat("speed",Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x));
	
		if(GetComponent<Rigidbody2D>().velocity.x > 0){
			GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);
		}else if(GetComponent<Rigidbody2D>().velocity.x < 0){
			GetComponent<Transform>().localScale = new Vector3(-1f,1f,1f);
		}
	}
}
