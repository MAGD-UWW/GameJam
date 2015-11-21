using UnityEngine;
using System.Collections;

public class sceneTransition : MonoBehaviour {
	public float timeLimit;


	void Start () {
		
	}

	void Update () {
		//Death ();
	}
	void Death(){
		timeLimit -= Time.deltaTime;
		Debug.Log (timeLimit);
		if (timeLimit <= 0) {
			//Application.LoadLevel ("gameOver");
			Debug.Log ("game over");
			//Set canvas to true
			//Rotate camera
			//Stops player from moving
		}
	}
	public void quitLevel() {
		Debug.Log ("Playing start screen");
	}
	public void restartLevel() {
		Debug.Log ("Restarting the level");
	}
}
