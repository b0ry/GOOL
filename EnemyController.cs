using UnityEngine;
using System.Collections;
using GOOL;

public class EnemyController : MonoBehaviour {
	private IMovement movementType = new ForwardMovement();
	public int baseScore;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (Camera.main.transform);
		Vector3 move = movementType.Move ();
		this.transform.Translate (move);
	}

	void OnCollisionEnter (Collision projectile) {
		if (projectile.gameObject.tag == "projectile") {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			float distX = Mathf.Abs(player.transform.position.x - this.transform.position.x);
			float distZ = Mathf.Abs(player.transform.position.z - this.transform.position.z);
			float distance = Mathf.Sqrt(distX*distX + distZ*distZ);
			int finalScore = baseScore+(int)distance;
			//BroadcastMessage("AddToScore",finalScore, SendMessageOptions.DontRequireReceiver);
			GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>().AddToScore(finalScore);
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
