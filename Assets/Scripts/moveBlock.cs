using UnityEngine;
using System.Collections;

public class moveBlock : MonoBehaviour {
	private bool dirRight = true;
	public float speed = 2.0f;
	public float xMax;
	public float xMin;
	
	void Update () {
		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		
		if(transform.position.x >= xMax) {
			dirRight = false;
		}
		
		if(transform.position.x <= xMin) {
			dirRight = true;
		}
	}
}
