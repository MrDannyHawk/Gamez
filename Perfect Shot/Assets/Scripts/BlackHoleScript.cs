using UnityEngine;
using System.Collections;

public class BlackHoleScript : MonoBehaviour {
	
	public float gravity = -10f;
	private float angle = 1f;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0,0,--angle * speed);
	}

	public void Attract(Transform spek){
		if (Vector3.Distance (spek.position, GetComponent<Transform>().position) < 2.75) {
			Vector3 gravityUp = (spek.position - GetComponent<Transform> ().position).normalized;

			Vector3 spekUp = spek.up;

			spek.GetComponent<Rigidbody2D> ().AddForce (gravityUp * gravity);

			Quaternion targetRotation = Quaternion.FromToRotation (spekUp, gravityUp) * spek.rotation;
			spek.rotation = Quaternion.Slerp (spek.rotation, targetRotation, 50 * Time.deltaTime);
		}
	}
}
