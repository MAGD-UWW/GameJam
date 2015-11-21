using UnityEngine;
using System.Collections;

public class checkpoints : MonoBehaviour {
	public Transform player;
	public Transform checkPoint;
	public Transform startPoint;
	public float maxFallValue;

	bool checkpoint;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("player").transform;
		checkPoint = GameObject.FindGameObjectWithTag ("checkpoint").transform;
		startPoint = GameObject.FindGameObjectWithTag ("startpoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		checkpoint = boolCheck.checkpoint; // references the boolean checkpoint in boolCheck script
		Falling ();
	}

	void Falling(){//function to check and see if player is falling off map
		if (player.position.y <= maxFallValue) {
			Respawn();
		}
	}

	public void Respawn(){// function to respawn player at checkpoint or start spot
		if (checkpoint == true) {
			player.position = checkPoint.position;
		} else {
			player.position = startPoint.position;
		}
	}

	void OnTriggerEnter(){
		if (player.position == checkPoint.position) {
			checkpoint = true;
			Debug.Log ("Checkpoint is true");
		}
	}
}
