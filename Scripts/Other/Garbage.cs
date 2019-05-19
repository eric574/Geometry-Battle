using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;

public class Garbage : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Actor")) {
			((Actor) other.GetComponent(typeof(Actor))).Kill();
		}

		if (other.CompareTag("Barrel")) {
			((Barrel)other.GetComponent(typeof(Barrel))).Explode();	
		}
		
		if (other.CompareTag("Wall")) return;
		Destroy(other);
	}
}
