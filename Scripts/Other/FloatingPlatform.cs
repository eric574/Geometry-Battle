using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour {
	
	private Vector2 startPos;

	public float height;
	public float speed;
	
	private void Start() {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		float y = Mathf.PingPong(Time.time * speed, height);
		transform.position = new Vector2(startPos.x, startPos.y + y);
	}
}
