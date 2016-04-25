using UnityEngine;
using System.Collections;

namespace GOOL {
	public interface IMovement {
		Vector3 Move ();
	}
	public class ForwardMovement : IMovement {
		private const float speed = 1f;
		public Vector3 Move() {
			//go.GetComponent<Rigidbody> ().AddForce(0f, 0f, Time.deltaTime * speed);
			return new Vector3 (0f,0f,Time.deltaTime * speed);
		}
	}
	public class UDMovement : IMovement {
		private IMovement movement;
		private float amplitude = Random.Range(0.5f, 1.5f);
		private float frequency = Random.Range(0.1f, 1f);

		public UDMovement (IMovement _movement) {
			movement = _movement;
		}

		public Vector3 Move() {
			Vector3 sMovement = movement.Move();
			sMovement += new Vector3 (0f,amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time)- Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))), 0f);
			return sMovement;
		}
	}
	public class LRMovement : IMovement {
		private IMovement movement;
		private float amplitude = Random.Range(0.5f, 1.5f);
		private float frequency = Random.Range(0.1f, 1f);
		
		public LRMovement (IMovement _movement) {
			movement = _movement;
		}
		
		public Vector3 Move() {
			Vector3 sMovement = movement.Move();
			sMovement += new Vector3 (amplitude*(Mathf.Cos(2*Mathf.PI*frequency*Time.time)- Mathf.Cos(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))), 0f, 0f);
			return sMovement;
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
			float mag = Random.Range (10f, 15f);
			float angle = Random.Range (0f, Mathf.PI);
			float posX = mag * Mathf.Cos (angle);
			float posZ = mag * Mathf.Sin (angle);
			Vector3 newPos = new Vector3 (posX,0f,posZ);

			GameObject g = GameObject.Instantiate(create,newPos,Quaternion.identity) as GameObject;
			IMovement forward = new ForwardMovement ();
			g.GetComponent<EnemyController> ().SetMovement (new UDMovement (forward));
		}
	}
	public class SpawnMonster : ISpawn {
		private GameObject create;
		
		public SpawnMonster (GameObject _create) {
			create = _create;
		}
		
		public void Spawn () {
			float mag = Random.Range (15f, 18f);
			float angle = Random.Range (0f, Mathf.PI);
			float posX = mag * Mathf.Cos (angle);
			float posZ = mag * Mathf.Sin (angle);
			Vector3 newPos = new Vector3 (posX,0f,posZ);
			
			GameObject g = GameObject.Instantiate(create,newPos,Quaternion.identity) as GameObject;
			IMovement forward = new ForwardMovement ();
			g.GetComponent<EnemyController> ().SetMovement (new LRMovement(new UDMovement (forward)));
		}
	}
	public class SpawnSpirit : ISpawn {
		private GameObject create;
		
		public SpawnSpirit (GameObject _create) {
			create = _create;
		}
		
		public void Spawn () {
			float mag = Random.Range (5f, 10f);
			float angle = Random.Range (0f, Mathf.PI);
			float posX = mag * Mathf.Cos (angle);
			float posZ = mag * Mathf.Sin (angle);
			Vector3 newPos = new Vector3 (posX,0f,posZ);
			
			GameObject g = GameObject.Instantiate(create,newPos,Quaternion.identity) as GameObject;
			IMovement forward = new ForwardMovement ();
			g.GetComponent<EnemyController> ().SetMovement (forward);
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
				projectile.GetComponent<BaseMissileBehaviour>().SetMovement(new ForwardMovement());
				cooldown = Time.time;
				GameObject.FindGameObjectWithTag("Player").GetComponent<SoundController>().ShootLaser();
			}
		}
	}
}
