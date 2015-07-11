using UnityEngine;
using System.Collections;

public class whiteCubeScript : MonoBehaviour {

	public float movementAngle  = 45;
	public float movementForce  = 5;
	public float movementRepeat = 1; // seconds

	private Vector3 directionLeft  = Quaternion.AngleAxis (360 - 45, Vector3.forward) * Vector3.left;
	private Vector3 directionRight = Quaternion.AngleAxis (45, Vector3.forward) * Vector3.right;

	private Vector3 movementDir;
	private bool isFalling = true;
	
	void Start () {
		spin ();
		InvokeRepeating ("jump", 1f, movementRepeat);
	}
	
	void Update () {
		// Nada
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Floor" && isFalling) {
			isFalling = false;
			spin ();
		}

		if (collision.gameObject.tag == "Wall")
			bounce();
	}
//
//	void OnCollisionStay(Collision collision) {
//		if (collision.gameObject.tag == "Wall")
//			bou
//	}
	
	void jump() {
		GetComponent<Rigidbody>().AddForce (movementDir * movementForce);
	}

	void bounce() {
		spin ();
	}

	void spin() {
		print ("X" + Random.value);
		print ("X" +Random.value);
		
		movementDir =  new Vector3(Random.value - 0.5f, 1, Random.value - 0.5f).normalized;
		print ("Moving to " + movementDir);
//		float newAngle = newDir.x > newDir.y ? 45 : (360 - 45);
//		movementDir = Quaternion.AngleAxis (360 - 45, Vector3.forward) * Vector3.left;
	}
}