using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHit : MonoBehaviour {

	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Enemy") {
			Destroy(enemy.gameObject);
			GameObject.FindGameObjectWithTag("UI").GetComponent<RawImage>().enabled = true;
			BroadcastMessage("Shake",SendMessageOptions.DontRequireReceiver);
			gameObject.GetComponent<SoundController>().PlayerIsHit();
		}
	}
}
