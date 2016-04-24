using UnityEngine;
using System;
using System.Collections.Generic;
using GOOL;

public class PlayerShoot : MonoBehaviour {
	private IWeapon activeWeapon;
	private List<IWeapon> weapons;
	public GameObject laser;

	// Use this for initialization
	void Start () {
		weapons = new List<IWeapon> { new Laser(0.5f, laser) };
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SetWeapon(weapons[0]);
			activeWeapon.Shoot();
		}
	}

	private void SetWeapon(IWeapon _weapon)
	{
		activeWeapon = _weapon;
	}
}
