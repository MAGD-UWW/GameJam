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
		timer.text = (Mathf.Round(timeLimit*100f)/100f).ToString ();
		Death ();
	}
	void Death(){
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
		deathUI.SetActive (true);
=======

>>>>>>> origin/master
=======
>>>>>>> parent of fa70964... Revert "Added Scene Transitions"
=======
>>>>>>> parent of fa70964... Revert "Added Scene Transitions"
		timeLimit -= Time.deltaTime;
		Debug.Log (timeLimit);
		if (timeLimit <= 0) {
			deathUI.SetActive (true);
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
