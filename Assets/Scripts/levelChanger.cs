using UnityEngine;
using System.Collections;

public class levelChanger : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	public void levelOne() {
		Debug.Log ("Loaded Level 1");
		//Application.LoadLevel ("Level1");
	}
	public void levelTwo() {
		Debug.Log ("Loaded Level 2");
		//Application.LoadLevel ("Level2");
	}
	public void levelThree() {
		Debug.Log ("Loaded Level 3");
		//Application.LoadLevel ("Level3");
	}
	public void levelFour() {
		Debug.Log ("Loaded Level 4");
		//Application.LoadLevel ("Level4");
	}
}
