using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sceneTransition : MonoBehaviour {
	public float timeLimit;
	public GameObject deathUI;
	public Text timer;


	void Start () {
		deathUI = GameObject.Find ("deathUI");
		deathUI.SetActive (false);
	}

	void Update () {
		timer.text = Mathf.Round(timeLimit).ToString ();
		Death ();
	}
	void Death(){
		deathUI.SetActive (true);
		timeLimit -= Time.deltaTime;
		Debug.Log (timeLimit);
		if (timeLimit <= 0) {
			timeLimit = 0;
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
