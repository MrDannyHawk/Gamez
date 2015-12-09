using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		//renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
		Debug.Log ("ggsdgdsgd");
		renderer.color = Color.green;

	}
}
