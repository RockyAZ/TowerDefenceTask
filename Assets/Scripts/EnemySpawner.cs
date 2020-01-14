using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: pulling enemies
public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private float delay = 0.4f;
	[SerializeField]
	private Transform spawnPos;
	[SerializeField]
	private EnemyData[] enemyDataArr;
	[SerializeField]
	private GameObject enemyPref;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(InfSpawning());
	}

	private void SpawnEnemy(EnemyData enemyData)
	{
		GameObject tmp = Instantiate(enemyPref, spawnPos.position, Quaternion.identity, GameController.Instance.Enemies);
		tmp.GetComponent<EnemyController>().Initiate(enemyData);
	}

	private void SpawnEnemy(string enemyType)
	{
		for (int i = 0; i < enemyDataArr.Length; i++)
		{
			if (enemyDataArr[i].Type == enemyType)
			{
				SpawnEnemy(enemyDataArr[i]);
				return;
			}
		}
		Debug.LogError("No EnemyType found");
	}

	private void SpawnEnemyRandom()
	{
		GameObject tmp = Instantiate(enemyPref, spawnPos.position, Quaternion.identity, GameController.Instance.Enemies);
		tmp.GetComponent<EnemyController>().Initiate(enemyDataArr[Random.Range(0, enemyDataArr.Length)]);
	}

	IEnumerator InfSpawning()
	{
		while (true)
		{
			SpawnEnemyRandom();
			yield return new WaitForSeconds(delay);
		}
	}


	//start WaveS handling
	public IEnumerator HandleWaves(WaveData[] waves)
	{
		for (int i = 0; i < waves.Length; i++)
		{
			StartCoroutine(DoWave(waves[i]));
			yield return new WaitForSeconds(waves[i].Duration);
			StopCoroutine("DoWave");
		}
	}
	//start WavE handling
	public IEnumerator HandleWave(WaveData waveData)
	{
		StartCoroutine(DoWave(waveData));
		yield return new WaitForSeconds(waveData.Duration);
		StopCoroutine("DoWave");
	}
	//then start emitting enemies with delay
	private IEnumerator DoWave(WaveData waveData)
	{
		while (true)
		{
			//do smart random here:
			int allRange = waveData.LowEnemyW + waveData.MidEnemyW + waveData.HighEnemyW;
			int rand = Random.Range(0, allRange);

			if (rand >= 0 && rand <= waveData.LowEnemyW)
				SpawnEnemy(EnemyData.EnemyLow);
			else if (rand >= waveData.LowEnemyW && rand <= waveData.LowEnemyW + waveData.MidEnemyW)
				SpawnEnemy(EnemyData.EnemyMid);
			else if (rand >= waveData.LowEnemyW + waveData.MidEnemyW && rand <= allRange)
				SpawnEnemy(EnemyData.EnemyHigh);
			yield return new WaitForSeconds(waveData.Delay);
		}
	}
}
