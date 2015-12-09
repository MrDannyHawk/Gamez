using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GameObject StartMenu;
	public GameObject ChooseMenu;
	public GameObject CharacterCreationMenu;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void closeCurrent(GameObject currentCanvas){	
		currentCanvas.SetActive (false);
	}
	
	public void OpenStartMenu(GameObject currentCanvas){
		closeCurrent(currentCanvas);
		StartMenu.SetActive (true);
	}

	public void OpenChooseMenu(GameObject currentCanvas){
		closeCurrent(currentCanvas);
		ChooseMenu.SetActive (true);
	}

	public void OpenCharacterCreationMenu(GameObject currentCanvas){
		closeCurrent(currentCanvas);
		CharacterCreationMenu.SetActive (true);
	}
}
