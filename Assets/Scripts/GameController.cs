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
	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => Enemies; set => Enemies = value; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
}
