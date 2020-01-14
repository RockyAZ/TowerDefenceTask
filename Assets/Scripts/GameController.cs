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
	private int gold = 500;

	private UIController ui;

	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => enemies; }
	public Transform Castle { get => castle; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		ui = this.gameObject.GetComponent<UIController>();
	}

	public bool ChangeGold(int value)//+value to plus -value to take away
	{
		gold += value;
		if (gold < 0)
			return false;
		ui.SetGold(gold);
		return true;
	}

	public void PrintShit()
	{
		print("shit");
	}

	public void GameOver()
	{
		Debug.LogError("GAME OVER");
	}
}
