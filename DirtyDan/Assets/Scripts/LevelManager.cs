using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlaerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlaerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Debug.Log ("Player Respawn");
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		foreach(Renderer rend in player.GetComponentsInChildren<Renderer> ())
			rend.enabled = false;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;

		yield return new WaitForSeconds(respawnDelay);
		
		player.GetComponent<Rigidbody2D> ().gravityScale = 5f;
		player.enabled = true;
		foreach(Renderer rend in player.GetComponentsInChildren<Renderer> ())
			rend.enabled = true;
		player.transform.position = currentCheckpoint.transform.position;
		Instantiate (respawnParticle, player.transform.position, player.transform.rotation);

	}
}
