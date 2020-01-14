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
		GameObject tmp = Instantiate(enemyPref,spawnPos.position, Quaternion.identity, GameController.Instance.Enemies);
		tmp.GetComponent<EnemyController>().Initiate(enemyData);
	}

	private void SpawnEnemyRandom()
	{
		GameObject tmp = Instantiate(enemyPref, spawnPos.position, Quaternion.identity, GameController.Instance.Enemies);
		tmp.GetComponent<EnemyController>().Initiate(enemyDataArr[Random.Range(0, enemyDataArr.Length)]);
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
