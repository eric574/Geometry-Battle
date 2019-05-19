using Players;
using UnityEngine;

namespace Enemies {
	public class BigEnemy : Enemy {

		private bool dead;
		
		private new void Start() {
			base.Start();
			EnemyStart();
			moveSpeed = 1500;
		}

		protected override void Behaviour(float playerX, RaycastHit2D hit2D) {
			
			
			if (playerX > transform.position.x)
				Move(1);
			else Move(-1);

			if (Random.Range(0, 1f) < 0.0025)
				Jump();

			if (Random.Range(0, 1f) < 0.007f)
				weaponScript.Fire();
		}

		protected override void OnDeathAction() {
			if (dead) return;
			dead = true;
			EnemyController.instance.bigBois--;
		}
	}
}
