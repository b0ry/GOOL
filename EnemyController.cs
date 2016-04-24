using UnityEngine;
using System.Collections;
using GOOL;

public class EnemyController : MonoBehaviour {
	private IMovement movementType;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movementType.Move (this.gameObject);
	}

	void OnCollisionEnter (Collision projectile) {
		if (projectile.gameObject.tag == "projectile") {
			GameObject g = Instantiate(smoke,transform.localPosition,transform.localRotation) as GameObject;
			Destroy(this.gameObject);
			Destroy (g, 3f);
			g.GetComponent<AudioSource>().pitch = Random.Range(1f,2.5f);
		}
	}

	public void SetMovement(IMovement _movementType) {
		movementType = _movementType;
	}
}
