using UnityEngine;
using System.Collections;

public class moveBlock : MonoBehaviour {
	public Vector3 xMove;
	public float maxZ;
	public float minZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movingBlock ();
		xMove = Vector3.forward * Time.deltaTime;
	}

	void movingBlock(){
		transform.Translate(xMove);
		if (transform.position.z == maxZ) {
			transform.Translate (-xMove);
		}
		if (transform.position.z == minZ){
			transform.Translate (xMove);
		}
	}
}
