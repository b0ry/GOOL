using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	public AudioSource playerHit;
	public static SoundController instance = null;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this) 
			Destroy (gameObject);
	}
	
	public void ShootLaser () {
		AudioSource laser = GameObject.FindGameObjectWithTag ("LaserSound").GetComponent<AudioSource> ();
		laser.pitch = Random.Range (0.45f, 0.55f);
		laser.Play ();
	}
	public void PlayerIsHit () {
		playerHit.Play ();
	}
}
