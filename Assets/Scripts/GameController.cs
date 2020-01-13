using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	[SerializeField]
	private Transform movePoints;
	[SerializeField]
	private Transform enemies;
	[SerializeField]
	private Transform castle;

	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => enemies; }
	public Transform Castle { get => castle; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
}
