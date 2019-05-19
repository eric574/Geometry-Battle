using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class Barrel : MonoBehaviour {

	public GameObject explosionFx;
	public GameObject damage;
	public GameObject effector;

	public void Explode() {
		AudioManager.Play("BarrelExplosion");
		CameraShake.ShakeOnce(0.7f, 2);
		explosionFx.SetActive(true);
		explosionFx.transform.parent = null;
		damage.SetActive(true);
		damage.transform.parent = null;
		effector.SetActive(true);
		effector.transform.parent = null;
		Destroy(gameObject);
	}
}
