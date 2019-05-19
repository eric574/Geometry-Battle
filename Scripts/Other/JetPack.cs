using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour {
	
	private Rigidbody2D rb;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		if (Input.GetKey(KeyCode.Space))
			Fly();
	}

	public void Fly() {
		rb.AddForce(transform.up * 2300 * Time.deltaTime);
		
	}

}
