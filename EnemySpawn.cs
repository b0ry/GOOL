using UnityEngine;
using System;
using System.Collections.Generic;
using GOOL;

public class EnemySpawn : MonoBehaviour {
	private ISpawn spawn;
	private List<ISpawn> enemies;
	private float timer = 0f;
	public GameObject ghost;
	public GameObject monster;
	public GameObject evilSpirit;

	// Use this for initialization
	void Start () {
		enemies = new List<ISpawn> { new SpawnGhost (ghost), new SpawnMonster(monster), new SpawnSpirit(evilSpirit) };
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3f) {
			timer = 0f;
			int type = UnityEngine.Random.Range(0,enemies.Count);
			SetEnemy (enemies[type]);
			spawn.Spawn();
		}
	}
	private void SetEnemy(ISpawn enemy)
	{
		spawn = enemy;
	}
}
