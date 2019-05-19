using UnityEngine;

namespace Players {
	public class Player : Actor {
		private new void Start() {
			base.Start();
			Health = Game.health;
		}

		private void Update() {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dirRelativeToPlayer = (mousePos - (Vector2) transform.position).normalized;
			//Input
			if (Input.GetKey(KeyCode.A))
				Move(-1);
			
			if (Input.GetKey(KeyCode.D))
				Move(1);

			if (Input.GetKeyDown(KeyCode.Space)) {
				Jump();
			}
			
			mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
			Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
			lookPos = lookPos - transform.position;
			float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
			gun.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

			if (Input.GetKey(KeyCode.Mouse0)) {
				Fire();
			}
			
			//Friction if not moving
			if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
				StopMoving();
				if (winding)
					Move(0);
			}
		}
		
	}
}
