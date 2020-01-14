using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	//[SerializeField]
	private EnemyData enemyData;

	private Transform trans;
	private Transform movepoints;
	private int currHealth;

	private bool isInit = false;//fix error when Destroy() called before Initiate()
	public EnemyData EnemyData { get => enemyData; set => enemyData = value; }

	// Start is called before the first frame update
	void Awake()
	{
		trans = this.transform;
		this.gameObject.tag = "Enemy";
	}

	public void Initiate(EnemyData data)
	{
		enemyData = data;
		GameObject tmp = Instantiate(enemyData.Model, trans);
		tmp.transform.localScale *= EnemyData.Scale;
		currHealth = enemyData.StartHealth;

		movepoints = GameController.Instance.MovePoints;
		StartCoroutine(Movement());
		isInit = true;
	}

	IEnumerator Movement()
	{
		foreach (Transform currentPoint in movepoints)
		{
			trans.LookAt(currentPoint, Vector3.up);
			while (Vector3.Distance(trans.position, currentPoint.position) > enemyData.SwitchDist)
			{
				Vector3 tmp = Vector3.MoveTowards(trans.position, currentPoint.position, enemyData.Speed * Time.deltaTime);
				tmp.y = trans.position.y;
				trans.position = tmp;
				yield return null;
			}
		}
		Destroy(trans.gameObject);
	}

	public void GetDamage(int dmg)
	{
		if (!isInit)
			return;
		currHealth -= dmg;
		if (currHealth <= 0)
			Death();
	}

	private void Death()
	{
		GameController.Instance.PlusGold(Random.Range(enemyData.MinGivenGold, enemyData.MaxGivenGold));
		Destroy(this.gameObject);
	}
}
