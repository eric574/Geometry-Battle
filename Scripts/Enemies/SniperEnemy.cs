using Players;
using UnityEngine;

namespace Enemies {
	public class SniperEnemy : Enemy {
		private bool dead;
		
		private new void Start() {
			base.Start();
			EnemyStart();
			
			maxMoveSpeed = 9f;
			moveSpeed *= 1.5f;
		}

		protected override void Behaviour(float playerX, RaycastHit2D hit2D) {
			float distFromPlayer = Vector2.Distance(transform.position, Game.currentPlayer.transform.position);
			if (distFromPlayer < 4) {
				if (playerX < transform.position.x)
					Move(1);
				else
					Move(-1);
			}

			if (Random.Range(0, 1f) < 0.04f) {
				if (hit2D.collider != null)
					if (hit2D.collider.gameObject.name == "Player")
						weaponScript.Fire();
			}
		}

		protected override void OnDeathAction() {
			if (dead) return;
			dead = true;
			EnemyController.instance.sniperBois--;
		}
	}
}
