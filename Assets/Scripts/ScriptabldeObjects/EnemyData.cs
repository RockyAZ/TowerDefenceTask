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
	private Material material;
	[SerializeField]
	private float scale;
	[SerializeField]
	private float switchDist;
	[SerializeField]
	private int minGivenGold;
	[SerializeField]
	private int maxGivenGold;

	public static string EnemyLow = "EnemyLow";
	public static string EnemyMid = "EnemyMid";
	public static string EnemyHigh = "EnemyHigh";


	public string Type { get => type; }
	public int StartHealth { get => startHealth; }
	public float Speed { get => speed; }
	public int Damage { get => damage; }
	public Material Material { get => material; }
	public float Scale { get => scale; }
	public float SwitchDist { get => switchDist; }
	public int MinGivenGold { get => minGivenGold; }
	public int MaxGivenGold { get => maxGivenGold; }
}
