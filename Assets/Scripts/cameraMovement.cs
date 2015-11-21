﻿using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
	private Transform charTransform;
	public GameObject character;
	public characterMovement charMoveScript;
	
	// Use this for initialization
	void Start () {
		charTransform = character.GetComponent<Transform>();
		charMoveScript = character.GetComponent<characterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(charTransform.position.x, charTransform.position.y + 15,charTransform.position.z-15);
		/*
		if(characterMovement.physics.wall == charMoveScript.gravity){
			transform.position = new Vector3(charTransform.position.x, 15,charTransform.position.z-15);
			Debug.Log("camaera shift!");
		} else {
			transform.position = new Vector3(charTransform.position.x, charTransform.position.y + 15,charTransform.position.z-15);
		}
*/
	}
}
