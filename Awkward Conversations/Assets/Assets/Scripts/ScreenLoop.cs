using UnityEngine;
using System.Collections;

public class ScreenLoop : MonoBehaviour {
	
	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;
	public GameObject bg4;
	public GameObject bg5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void moveRight(){
		Vector3 rightMost = bg5.transform.position;
		
		bg5.transform.position = bg4.transform.position;
		bg4.transform.position = bg3.transform.position;
		bg3.transform.position = bg2.transform.position;
		bg2.transform.position = bg1.transform.position;
		bg1.transform.position = rightMost;

		
		Vector3 rightMostSize = bg5.transform.transform.localScale;
		
		bg5.transform.localScale = bg4.transform.localScale;
		bg4.transform.localScale = bg3.transform.localScale;
		bg3.transform.localScale = bg2.transform.localScale;
		bg2.transform.localScale = bg1.transform.localScale;
		bg1.transform.localScale = rightMostSize;
	}

	public void moveLeft(){
		Vector3 leftMost = bg1.transform.position;
		
		bg1.transform.position = bg2.transform.position;
		bg2.transform.position = bg3.transform.position;
		bg3.transform.position = bg4.transform.position;
		bg4.transform.position = bg5.transform.position;
		bg5.transform.position = leftMost;

		
		Vector3 leftMostSize = bg1.transform.localScale;
		
		bg1.transform.localScale = bg2.transform.localScale;
		bg2.transform.localScale = bg3.transform.localScale;
		bg3.transform.localScale = bg4.transform.localScale;
		bg4.transform.localScale = bg5.transform.localScale;
		bg5.transform.localScale = leftMostSize;
	}
}
