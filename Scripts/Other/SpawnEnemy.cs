using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public GameObject fx, popFx;

	private void Start() {
		Invoke("Spawn", 2f);
	}

	private void Spawn() {
		Instantiate(enemy, transform.position, transform.rotation);
		GameObject ps = Instantiate(popFx, transform.position, transform.rotation);
		ps.GetComponent<ParticleSystem>().startColor = enemy.GetComponent<SpriteRenderer>().color;
		Destroy(fx);
	}
}
