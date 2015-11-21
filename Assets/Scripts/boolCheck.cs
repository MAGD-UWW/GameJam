using UnityEngine;
using System.Collections;

public class boolCheck : MonoBehaviour {
	public static bool checkpoint = false;

	
	// Update is called once per frame
	void OnTriggerEnter () {
		checkpoint = true;
		Debug.Log ("checkpoint is active!");
	}
}
