using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		StartCoroutine(Spawning());
	}

	private void SpawnEnemy(EnemyData enemyData)
	{
		GameObject tmp = Instantiate(enemyPref, GameController.Instance.Enemies);
		tmp.GetComponent<EnemyController>().EnemyData = enemyData;
	}

	private void SpawnEnemyRandom()
	{
		GameObject tmp = Instantiate(enemyPref, spawnPos);
		tmp.GetComponent<EnemyController>().EnemyData = enemyDataArr[Random.Range(0, enemyDataArr.Length - 1)];
	}

	IEnumerator Spawning()
	{
		while(true)
		{
			SpawnEnemyRandom();
			yield return new WaitForSeconds(delay);
		}
	}
}
