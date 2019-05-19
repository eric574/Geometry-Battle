using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Vector3 basePostion;
	public Vector3 offset;
	public Camera currentCamera;

	private float yOffset;

	private Vector3 velocity = Vector3.zero;
	private float moveSmoothTime = 2f;

	private float zoomVel;
	private float zoomSpeed = 1f;

	private float standardZoom = 11f;

	private void Start() {
		basePostion = transform.position;
		yOffset = offset.y;
	}

	// Update is called once per frame
	void Update () {
		if (!Game.inGame || Game.currentPlayer == null) return;
		float newZoom = standardZoom + (Mathf.Abs(Vector2.Distance(transform.position, Game.currentPlayer.transform.position)))/8;

		Vector3 playerRelativeToCamPos = basePostion - Game.currentPlayer.transform.position;
		Vector3 newPosition = basePostion - playerRelativeToCamPos * 0.1f + offset;
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, moveSmoothTime);
		offset.y = yOffset + newZoom / 6;

		currentCamera.orthographicSize =
			Mathf.SmoothDamp(currentCamera.orthographicSize, newZoom, ref zoomVel, zoomSpeed);
		
	}
}
