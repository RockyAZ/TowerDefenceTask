using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data", order = 52)]
public class TowerData : ScriptableObject
{
	[SerializeField]
	private string type;
	[SerializeField]
	private int price;
	[SerializeField]
	private float range;
	[SerializeField]
	private float interval;
	[SerializeField]
	private int damage;
	[SerializeField]
	private GameObject model;

	public string Type { get => type; }
	public int Price { get => price; }
	public float Range { get => range; }
	public float Interval { get => interval; }
	public int Damage { get => damage; }
	public GameObject Model { get => model; }
}
