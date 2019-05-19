using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float damage;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Actor")) {
			Actor script = other.GetComponent(typeof(Actor)) as Actor;
			script.Damage(damage);
		}
	}
}
