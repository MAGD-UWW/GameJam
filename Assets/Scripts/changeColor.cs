using UnityEngine;
using System.Collections;

public class changeColor : MonoBehaviour {
	public GameObject white1, white2;
	public GameObject black1, black2;
	public float waitTime;
	bool white, black;
	public float timer;

	// Use this for initialization
	void Start () {
		white = true;
		black = false;
		white1 = GameObject.Find ("colorChangerW1");
		white2 = GameObject.Find ("colorChangerW2");
		black1 = GameObject.Find ("colorChangerB1");
		black2 = GameObject.Find ("colorChangerB2");
	}
	
	// Update is called once per frame
	void Update () {
		colorChange ();
		Timer ();
	}

	void colorChange(){
		if (white == true) {
			white1.SetActive (true);
			white2.SetActive (true);
			black1.SetActive (false);
			black2.SetActive (false);
		}
		if (black == true) {
			white1.SetActive (false);
			white2.SetActive (false);
			black1.SetActive (true);
			black2.SetActive (true);
		}

	}

	void Timer(){
		timer += Time.deltaTime;

		Debug.Log (timer);
		if (timer >= 3) {
			white =! white;
			black =! black;
			timer = 0;
		}
	}
	
}
