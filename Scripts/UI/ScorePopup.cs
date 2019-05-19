using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScorePopup : MonoBehaviour {

	private Vector2 newPos;
	private Vector3 vel1 = Vector3.zero;
	private float speed = 1f;
	
	private Vector3 newScale;
	private Vector3 vel3 = Vector2.zero;

	private float alpha;
	private Color newColor;
	private float vel4;

	public TextMeshProUGUI text;
	
	private void Start() {
		newPos = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(1, 2.5f));

		newScale = transform.localScale * 0.7f;

		alpha = 1;
		newColor = text.color;
		newColor = new Color(newColor.r, newColor.g, newColor.b, 0f);
	}

	private void Update() {
		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref vel1, speed);
		transform.localScale = Vector3.SmoothDamp(transform.localScale, newScale, ref vel3, speed);
		alpha = Mathf.SmoothDamp(alpha, 0, ref vel4, speed);
		
		newColor = new Color(newColor.r, newColor.g, newColor.b, alpha);
		text.color = newColor;

		if (alpha <= 0.05) {
			Destroy(gameObject);
		}
	}
}
