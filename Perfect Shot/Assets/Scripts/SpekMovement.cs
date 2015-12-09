using UnityEngine;
using System.Collections;

public class SpekMovement : MonoBehaviour {
	
	Vector2 velocity;

	public float forwardSpeed = 485f;
	public GameObject guide;

	private bool up = false,
				down = false,
				left = false,
				right = false,
	rotateSprite = false,
	fire=false,
	fired=false; 

	public BlackHoleScript blackHole;
	private Transform myTransform;
	private GameObject[] blackHoles;

	private Vector3 mousePos;
	

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();

		blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");
	}
	
	// Update is called once per frame
	void Update () {
		//blackHole.Attract (myTransform);

		foreach (GameObject go in blackHoles) {
			BlackHoleScript b = (BlackHoleScript) go.GetComponent(typeof(BlackHoleScript));;
			b.Attract(myTransform);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			up    = true;
		}else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			down  = true;
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			left  = true;
		}else if(Input.GetKeyDown(KeyCode.RightArrow)) {
			right = true;
		}

		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		if(Input.GetKeyDown(KeyCode.Space)) {
			fire    = true;
		}

	}

	void FixedUpdate(){

		
		float deltaY = mousePos.y - transform.position.y;
		float deltaX = mousePos.x - transform.position.x;
		
		
		float angleInDegrees = Mathf.Atan(deltaY / deltaX) * 180 / Mathf.PI;
		transform.rotation = Quaternion.Euler (0, 0, angleInDegrees);
		
		//Debug.Log ("x1: " + transform.position.x + " y1: " + transform.position.y + " x2: " + mousePos.x + "y2: " + mousePos.y + " __ angle: " + angleInDegrees);
		
		fired = true;

		if (fire) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * forwardSpeed * Mathf.Sin (deltaY / deltaX) );
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forwardSpeed * Mathf.Cos (deltaY / deltaX));

			fire = false;
			guide.SetActive(false);
		}


		if (!fire) {
			if (!fired) {
			
			}
		}
		
		if (up) {
			/*velocity = GetComponent<Rigidbody2D>().velocity;
			if(Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
				velocity.y = Mathf.Abs(velocity.x); 
			velocity.x = 0f;
			GetComponent<Rigidbody2D>().velocity = velocity;*/
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * forwardSpeed );
			up    = false;
		}else if(down){
			/*velocity = GetComponent<Rigidbody2D>().velocity;
			if(Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
				velocity.y = -1 * Mathf.Abs(velocity.x);
			velocity.x = 0f; 
			GetComponent<Rigidbody2D>().velocity = velocity;*/
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * forwardSpeed  * -1);
			down  = false;
		}else if(left){
			/*velocity = GetComponent<Rigidbody2D>().velocity;
			if(Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x))
				velocity.x = -1 * Mathf.Abs(velocity.y);
			velocity.y = 0f;
			GetComponent<Rigidbody2D>().velocity = velocity;*/
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed * -1);
			left  = false;
		}else if(right){
			/*velocity = GetComponent<Rigidbody2D>().velocity;
			if(Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x))
				velocity.x = Mathf.Abs(velocity.y);
			velocity.y = 0f;
			GetComponent<Rigidbody2D>().velocity = velocity;*/
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );
			right = false;
		}
	}
}
