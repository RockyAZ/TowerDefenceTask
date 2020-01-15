using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public TextMeshProUGUI del;
	[Space]
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
	[Space]
	[SerializeField]
	private Material towerPointMat;
	[SerializeField]
	private Material towerPointOutlineMat;
	[Space]
	[SerializeField]
	private WaveData[] waveArr;
	private int wavesCounter = 0;


	private EnemySpawner enemySpawner;
	private UIController ui;

	public Transform MovePoints { get => movePoints; }
	public Transform Enemies { get => enemies; }
	public Transform Castle { get => castle; }
	public GameObject TowerPref { get => towerPref; }
	public TowerData[] TowerDatas { get => towerDatas; }
	public int Gold { get => gold; }
	public Material TowerPointMat { get => towerPointMat; }
	public Material TowerPointOutlineMat { get => towerPointOutlineMat; }

	public void PrintShit(string str)
	{
		del.text = str;
	}

	private void Awake()
	{
		if (Instance == null)
			Instance = this;

		enemySpawner = this.gameObject.GetComponent<EnemySpawner>();

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

	public bool MinusGold(int value)
	{
		gold -= value;
		if (gold < 0)
			return false;
		ui.SetGold(gold);
		return true;
	}

	public void GameOver()
	{
		Debug.LogError("GAME OVER");
	}

	public void StartWaves()
	{
		StartCoroutine(enemySpawner.HandleWaves(this.waveArr));
	}

	public void AddWave()
	{
		wavesCounter++;
		ui.SetWaveText(wavesCounter, waveArr.Length);
	}
}
