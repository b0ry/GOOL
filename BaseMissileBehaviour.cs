using UnityEngine;
using System.Collections;
using GOOL;

public class BaseMissileBehaviour : MonoBehaviour {
	private IMovement movementType = new ForwardMovement();

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = movementType.Move ();
		this.transform.Translate (move);
	}

	public void SetMovement(IMovement _movementType) {
		movementType = _movementType;
	}
}
