using Audio;
using Players;
using UnityEngine;

namespace Enemies {
	public class SuicideEnemy : Enemy {

		private bool dead;
		
		private bool readyToJump = true;
		public GameObject explosion;
		
		private new void Start() {
			base.Start();
			jumpForce *= 0.65f;
			maxMoveSpeed = 6f;
			moveSpeed *= 0.5f;
			maxJumps = 2;
			Destroy(gun);
			EnemyStart();
		}
		
		protected override void Behaviour(float playerX, RaycastHit2D hit2D) {
			float playerY = Game.currentPlayer.transform.position.y;

			if (playerX > transform.position.x)
				Move(1);
			else Move(-1);

			if (playerY > (transform.position.y + 1.5f) && readyToJump) {
				Jump();
				readyToJump = false;
				Invoke("JumpCoolDown", 0.3f);
			}
			
			if(Vector2.Distance(transform.position, Game.currentPlayer.transform.position) < 1.2f)
				Kill();

		}

		protected override void OnDeathAction() {
			if (dead) return;
			dead = true;
			EnemyController.instance.suicideBois--;
			AudioManager.Play("SuicideExplosion");
			Instantiate(explosion, transform.position, transform.rotation);
			CameraShake.ShakeOnce(0.5f, 1.2f);
		}

		private void JumpCoolDown() {
			readyToJump = true;
		}
	}
}
