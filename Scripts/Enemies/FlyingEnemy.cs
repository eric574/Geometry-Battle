using JetBrains.Annotations;
using Players;
using UnityEngine;

namespace Enemies {
	public class FlyingEnemy : Enemy {
		private bool dead;
		
		private new void Start() {
			base.Start();
			EnemyStart();
		}
	
		protected override void Behaviour(float playerX, RaycastHit2D hit2D) {
			float playerY = Game.currentPlayer.transform.position.y;
		
			//Move hoizontally
			if (playerX > transform.position.x)
				Move(1);
			else Move(-1);
		
			//Move vertically
			if (playerY > transform.position.y)
				GetRb().AddForce(Vector2.up * Time.deltaTime * 200);
			if (playerY < transform.position.y + 5)
				GetRb().AddForce(Vector2.down * Time.deltaTime * 200);

			if (Random.Range(0, 1f) < 0.01f)
				weaponScript.Fire();
		}

		protected override void OnDeathAction() {
			if (dead) return;
			dead = true;
			EnemyController.instance.flyingBois--;
		}

	
	}
}
