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
	[Space]
	[SerializeField]
	private GameObject towerPref;
	[SerializeField]
	private TowerData[] towerDatas;
	[Space]
	[SerializeField]
	private int gold = 500;
	[SerializeField]
	private int minGivenGold = 10;
	[SerializeField]
	private int maxGivenGold = 50;

	private UIController ui;

	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => enemies; }
	public Transform Castle { get => castle; }
	public GameObject TowerPref { get => towerPref; }
	public TowerData[] TowerDatas { get => towerDatas; }
	public int Gold { get => gold; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		ui = this.gameObject.GetComponent<UIController>();
		ui.SetGold(gold);
	}

	public bool PlusGold(int value)
	{
		gold += value;
		if (gold < 0)
			return false;
		ui.SetGold(gold);
		return true;
	}

	public void AddRandomGold()
	{
		PlusGold(Random.Range(minGivenGold, maxGivenGold));
	}

	public bool MinusGold(int value)
	{
		gold -= value;
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
