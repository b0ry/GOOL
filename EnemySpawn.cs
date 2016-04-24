using UnityEngine;
using System;
using System.Collections.Generic;
using GOOL;

public class EnemySpawn : MonoBehaviour {
	private ISpawn spawn;
	private List<ISpawn> enemies;
	private float timer = 0f;
	public GameObject ghost;

	// Use this for initialization
	void Start () {
		enemies = new List<ISpawn> { new SpawnGhost (ghost) };
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3f) {
			timer = 0f;
			SetEnemy (enemies[0]);
			spawn.Spawn();
		}
	}
	private void SetEnemy(ISpawn enemy)
	{
		spawn = enemy;
	}
}
