using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {
	public Rigidbody charRB;
	public Transform charTransform;
	public float speed = 10.0f;
	public float jumpThrust = -20.0f;
	public float flipTime = 0.5f;
	private float currTime;
	private bool jumped = false;
	public int rotationForce = 20;
	private Transform wall;
	
	// variables for movement
	private float moveH, moveV;
	
	public enum side {
		white,
		black
	}
	side up;
	
	public enum lastKey {
		up, 
		down, 
		left, 
		right
	};
	lastKey last; // create instance of the enum
	
	public enum physics{
		ground,
		wall
	}
	public physics gravity;
	
	
	public bool grounded = false;
	
	public bool onWall = false;
	
	//public Vector3 eulerAngleVelocity;
	
	// Use this for initialization
	void Start () {
		charRB = GetComponent<Rigidbody>();
		charTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		moveH = Input.GetAxis("Horizontal") * speed;
		moveV = Input.GetAxis("Vertical") * speed;
		
		
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("mouse clicked");
			//transform.rotation = Quaternion.identity;
			//transform.rotation = Quaternion.identity;
			//charRB.rotation = Quaternion.Euler(0, 0, 180);
		}
		
		// keep track of which direciton was last moved
		//Debug.Log(h + " " + v);
		
		// This keeps track of the last direction moved
		if (Mathf.Abs(moveH) > Mathf.Abs(moveV)) {
			if(moveH > 0) {
				last = lastKey.right;
			} else {
				last = lastKey.left;
			}
		} else if( moveV > 0 ) {
			last = lastKey.up;
		} else if( moveV < 0 ) {
			last = lastKey.down;
		}
				
		checkPhysics();

		// make disc jump
		if(Input.GetButtonDown("Jump")){
			// call jump function
			jump();        
			// toggle 'jumped' state         
			jumped = true;
			grounded = false;
			// start timer to check when to start the flip
			currTime = Time.time;
			charRB.freezeRotation = false;
			//Debug.Log ("space pressed!");
		}
		
		// FLIP
		// after jump, waits .5 seconds then flips
		if(jumped && (Time.time - currTime > .5)){
			flip (last);
			jumped = false;
		}
		
		
		//check if character is not moving, and re-orient itself
		//Debug.Log (transform.rotation.x + " "+  transform.rotation.y + " " + transform.rotation.z);
				
						
		if (grounded){
			charRB.freezeRotation = true;
			//charRB.angularVelocity = Vector3.zero;
			//Debug.Log(charTransform.rotation.eulerAngles);
			if (((charTransform.eulerAngles.z > 170) && (charTransform.eulerAngles.z < 190))){
				charTransform.rotation = Quaternion.Euler(0, 0, 180);
				Debug.Log("black side up");
			} else{
				charTransform.rotation = Quaternion.Euler(0, 0, 0);
				Debug.Log("white side up");
			}
			//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
		}
	}
	
	void checkPhysics(){
		//move the disc around, based on being on the wall or ground
		
		if(onWall == true){
			gravity = physics.wall;
		}
		if(grounded == true){
			gravity = physics.ground;
		}
		
		if(gravity == physics.ground){
			charTransform.Translate(moveH,0,moveV,Space.World);
			Physics.gravity = new Vector3( 0, -9.8f, 0);
		} else {
			charTransform.Translate(moveH,moveV,0,Space.World);
			Physics.gravity = new Vector3( 0,0,9.8f);
		}
	}
	
	void jump(){
		// gives rigidbody an upward velocity
		if(grounded){
			charRB.velocity = new Vector3(0,jumpThrust,0);
		}
		if(onWall ){
			charRB.velocity = new Vector3(0,0,-jumpThrust);
		}
	}
	
	void flip(lastKey last){ // send the last direction moved, which dictates the flip direction
		Debug.Log ("flipping!");
		Debug.Log(last);
		if (last == lastKey.up){
			charRB.AddRelativeTorque(transform.right * rotationForce, ForceMode.Impulse);
		}
		if (last == lastKey.down){
			charRB.AddRelativeTorque(transform.right * -rotationForce, ForceMode.Impulse);
		} 
		if (last == lastKey.left && (gravity == physics.ground)){
			charRB.AddRelativeTorque(transform.forward * rotationForce, ForceMode.Impulse);
		}
		if (last == lastKey.right && (gravity == physics.ground)){
			charRB.AddRelativeTorque(transform.forward * -rotationForce, ForceMode.Impulse);
		}
		
		// Physics shift for on the wall
		if (last == lastKey.left && (gravity == physics.wall)){
			charRB.AddRelativeTorque(transform.up * -rotationForce, ForceMode.Impulse);
		}
		if (last == lastKey.right && (gravity == physics.wall)){
			charRB.AddRelativeTorque(transform.up * rotationForce, ForceMode.Impulse);
		}
	}
	
	// collision with walls interaction
	
	void OnTriggerEnter(Collider col){
		if (col.CompareTag("StickyWall")){
			Debug.Log ("stickywall");
			wall = col.GetComponent<Transform>();
			//charRB.rotation= Quaternion.euler(0, 90, 0);
			//charRB.isKinematic = true;
			//charRB.useGravity = false;
			
			// FLIP CORRECTLY TO WALL
			charRB.freezeRotation = true;
			if(charTransform.eulerAngles.x > 80.0f && charTransform.eulerAngles.x < 100.0f){
				charTransform.rotation = Quaternion.Euler(90, 0, 0);
				//charTransform.rotation = Quaternion.Euler(270, 0, 0);
			} else {
				//charTransform.rotation = Quaternion.Euler(90, 0, 0);
				charTransform.rotation = Quaternion.Euler(270, 0, 0);
			}
		
			charTransform.position = new Vector3(charTransform.position.x,charTransform.position.y, wall.position.z-0.76f); // check wall width!
			charRB.angularVelocity = Vector3.zero;
			charRB.detectCollisions = true;
			onWall = true;
			//Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
			//charRB.MoveRotation(charRB.rotation * deltaRotation);
		} 
		if (col.CompareTag("ground")){
			grounded = true;
			Debug.Log ("grounded!");
		}
	}
	
	void OnTriggerExit(Collider col) {
		if (col.CompareTag("StickyWall")){
			onWall = false;
		}
		if (col.CompareTag("ground")){
			grounded = false;
		}	
	}
}
