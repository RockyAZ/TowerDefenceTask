using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
	[SerializeField]
	private int startHealth;
	[SerializeField]
	private float speed;
	[SerializeField]
	private int damage;
	[SerializeField]
	private GameObject model;
	[SerializeField]
	private float scale;

	public int StartHealth { get => startHealth; }
	public float Speed { get => speed; }
	public int Damage { get => damage; }
}
