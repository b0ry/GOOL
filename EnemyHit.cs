using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision projectile) {
		if (projectile.gameObject.tag == "projectile") {
			GameObject g = Instantiate(smoke,transform.localPosition,transform.localRotation) as GameObject;
			Destroy(this.gameObject);
			Destroy (g, 3f);
			g.GetComponent<AudioSource>().pitch = Random.Range(1f,2.5f);
		}
	}
}
