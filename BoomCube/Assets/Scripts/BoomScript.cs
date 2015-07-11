using UnityEngine;
using System.Collections;

public class BoomScript : MonoBehaviour {

	public int interval = 1;
	public float deltaMultiplier = 1;
	public int maxBooms = 3;

	private float lastBoom;
	private int boomCount = 0;

	// Use this for initialization
	void Start () {
		lastBoom = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - lastBoom >= interval) {
			if (++boomCount == maxBooms + 1) {
				Destroy(gameObject);
				return;
			}

			lastBoom = Time.realtimeSinceStartup;

			Vector3 delta = new Vector3(
				Random.value * deltaMultiplier,
				Random.value * deltaMultiplier,
				Random.value * deltaMultiplier
			);

			Instantiate(this.gameObject, this.transform.position + delta, this.transform.rotation);
			this.transform.position -= delta;

			print("Boom!");
		}
	}
}
