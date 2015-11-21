using UnityEngine;
using System.Collections;

public class moveBlockZ : MonoBehaviour {
	private bool dirZ = true;
	//public float speed = 2.0f;
	public float zMax;
	public float zMin;
	
	// Update is called once per frame
	void Update () {
		if (dirZ == true) {
			transform.Translate (Vector3.forward*Time.deltaTime);
		} else {
			transform.Translate (-Vector3.forward*Time.deltaTime);
		}

		if (transform.position.z >= zMax) {
			dirZ = false;
		}

		if (transform.position.z <= zMin) {
			dirZ = true;
		}
	}
}
