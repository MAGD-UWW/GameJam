using UnityEngine;
using System.Collections;

public class titleScreenTransition : MonoBehaviour {

	
	void Update () {
		if(Input.GetKeyDown ("space")){
			Debug.Log ("Changing the Level");
			//Application.LoadLevel ("LevelChange");
		}
	
	}
}
