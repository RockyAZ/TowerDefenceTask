using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	[SerializeField]
	private Transform movePoints;
	[SerializeField]
	private Transform enemies;
	[SerializeField]
	private Transform castle;
	[SerializeField]
	private TextMeshPro goldText;

	[SerializeField]
	private int gold = 500;

	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => enemies; }
	public Transform Castle { get => castle; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	public bool ChangeGold(int value)//+value to plus -value to take away
	{
		gold += value;
		if (gold < 0)
			return false;
		goldText.text = gold.ToString();
		return true;
	}
}
