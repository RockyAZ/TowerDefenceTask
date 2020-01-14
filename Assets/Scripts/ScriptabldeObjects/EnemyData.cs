using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
	[SerializeField]
	private string type;
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
	[SerializeField]
	private float switchDist;

	public string Type { get => type; }
	public int StartHealth { get => startHealth; }
	public float Speed { get => speed; }
	public int Damage { get => damage; }
	public GameObject Model { get => model; }
	public float Scale { get => scale; }
	public float SwitchDist { get => switchDist; }
}
