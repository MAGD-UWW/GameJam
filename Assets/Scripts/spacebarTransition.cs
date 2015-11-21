using UnityEngine;
using System.Collections;

public class spacebarTransition : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("Moving to level selection");
			//Application.LoadLevel ("LevelSelection");
		}
	}
}
