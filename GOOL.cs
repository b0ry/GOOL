using UnityEngine;
using System.Collections;

namespace GOOL {
	public interface IMovement {
		void Move (GameObject entity);
	}
	public class LinearMovement : IMovement {
		private const float speed = 200f;
		public void Move(GameObject go) {
			//go.GetComponent<Rigidbody> ().AddForce(0f, 0f, Time.deltaTime * speed);
			go.transform.Translate (0f, 0f, Time.deltaTime * speed);
		}
	}
	public class SinusoidalMovement : IMovement {
		private IMovement movement;
		private const float amplitude = 1f;
		private const float frequency = 2f;
		private const float speed = 10f;

		/*public SinusoidalMovement (IMovement _movement) {
			movement = _movement;
		}*/

		public void Move(GameObject go) {
			float yMovement = amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time)- Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime)));
			go.transform.Translate (0f, yMovement, 0f);
		}
	}

	public interface ISpawn {
		void Spawn ();
	}
	//Concrete
	public class SpawnGhost : ISpawn {
		private GameObject create;

		public SpawnGhost (GameObject _create) {
			create = _create;
		}

		public void Spawn () {
			float mag = Random.Range (5f, 10f);
			float angle = Random.Range (0f, Mathf.PI);
			float posX = mag * Mathf.Cos (angle);
			float posZ = mag * Mathf.Sin (angle);
			Vector3 newPos = new Vector3 (posX,0f,posZ);

			GameObject g = GameObject.Instantiate(create,newPos,Quaternion.identity) as GameObject;
			g.transform.LookAt (Camera.main.transform);
			g.GetComponent<EnemyController> ().SetMovement (new SinusoidalMovement ());
		}
	}

	public interface IWeapon {
		void Shoot();
	}
	//Concrete
	public class Laser : IWeapon {
		private float delay;
		private float cooldown;
		private GameObject laser;
		
		public Laser(float _delay, GameObject _laser) {
			delay = _delay;
			laser = _laser;
		}
		
		public void Shoot() {
			if (Time.time > delay + cooldown)
			{
				Transform cam = Camera.main.transform; 
				GameObject projectile = GameObject.Instantiate(laser, cam.position, cam.rotation) as GameObject;
				projectile.transform.position -= new Vector3(0f,0.5f,0f);
				//projectile.transform.eulerAngles = owner.transform.eulerAngles;
				projectile.GetComponent<BaseMissileBehaviour>().SetMovement(new LinearMovement());
				cooldown = Time.time;
			}
		}
	}
}
