using UnityEngine;
using System.Collections;

public class checkpoints : MonoBehaviour {
	public Transform player;
	public Transform checkPoint;
	public Transform startPoint;
	public float maxFallValue;
	
	public GameObject character;

	bool checkpoint;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("player").transform;
		checkPoint = GameObject.FindGameObjectWithTag ("checkpoint").transform;
		startPoint = GameObject.FindGameObjectWithTag ("startpoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		checkpoint = boolCheck.checkpoint; // references the boolean checkpoint in boolCheck script
		character = GameObject.FindWithTag("player");
		if(character == null){
			//Debug.Log("finging new char");
			character = GameObject.FindWithTag("player");
			}
		Falling ();
	}

	void Falling(){//function to check and see if player is falling off map
		if (character.transform.position.y <= maxFallValue) {
			DestroyObject(character);
			Respawn();
			Debug.Log("should respawn");
		}
	}

	public void Respawn(){// function to respawn player at checkpoint or start spot
		Debug.Log ("new instance");
		if (checkpoint == true) {
			character = Instantiate(character, checkPoint.position, Quaternion.Euler(0, 0,0)) as GameObject;
			
			//player.position = checkPoint.position;
		} else {
			character = Instantiate(character, checkPoint.position, Quaternion.Euler(0, 0,0)) as GameObject;
			//player.position = startPoint.position;
		}
		character = GameObject.Find("Character");
	}

	void OnTriggerEnter(){
		if (character.transform.position == checkPoint.position) {
			checkpoint = true;
			Debug.Log ("Checkpoint is true");
		}
	}
}
