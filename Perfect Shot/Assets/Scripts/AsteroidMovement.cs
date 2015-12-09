using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	public float offset = 3f;
	public float speed = 1f;
	public bool vert = false;
	private bool goingUp = true;
	private Vector2 velocity;
	private Vector3 pos;
	private Vector3 basePosition;

	// Use this for initialization
	void Start () {
		pos 	 = GetComponent<Transform>   ().position;
		velocity = GetComponent<Rigidbody2D> ().velocity;
		basePosition = pos;

		if (goingUp) {
			if(vert){
				velocity.y = speed;
				GetComponent<Rigidbody2D>().velocity = velocity;
			}else{
				velocity.x = speed;
				GetComponent<Rigidbody2D>().velocity = velocity;
			}
		} else {
			if(vert){
				velocity.y = -1 * speed;
				GetComponent<Rigidbody2D>().velocity = velocity;
			}else{
				velocity.x = -1 * speed;
				GetComponent<Rigidbody2D>().velocity = velocity;
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		pos		 = GetComponent<Transform>   ().position;
		velocity = GetComponent<Rigidbody2D> ().velocity;

		if (goingUp) {
			if(vert){
				if(pos.y > basePosition.y + offset){
					velocity.y = -1 * speed;
					goingUp = false;
				}
			}else{
				if(pos.x > basePosition.x + offset){
					velocity.x = -1 * speed;
					goingUp = false;
				}
			}
		} else {
			if(vert){
				if(pos.y < basePosition.y - offset){
					velocity.y = speed;
					goingUp = true;
				}
			}else{
				if(pos.x < basePosition.x - offset){
					velocity.x = speed;
					goingUp = true;
				}
			}
		}

		GetComponent<Rigidbody2D> ().velocity = velocity;
	}
}
