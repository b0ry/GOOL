using UnityEngine;
using System.Collections;
using GOOL;

public class BaseMissileBehaviour : MonoBehaviour {
	private IMovement movementType;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		movementType.Move (this.gameObject);
	}

	public void SetMovement(IMovement _movementType) {
		movementType = _movementType;
	}
}
