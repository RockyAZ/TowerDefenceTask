using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "Wave Data", order = 53)]
public class WaveData : ScriptableObject
{
	[SerializeField]
	private float duration;
	[SerializeField]
	private float delay;
	[SerializeField]
	private int lowEnemyW;//lowEnemyWeight
	[SerializeField]
	private int midEnemyW;
	[SerializeField]
	private int highEnemyW;

	public float Duration { get => duration; }
	public float Delay { get => delay; }
	public int LowEnemyW { get => lowEnemyW; }
	public int MidEnemyW { get => midEnemyW; }
	public int HighEnemyW { get => highEnemyW; }
}
