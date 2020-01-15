using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
	//[SerializeField]
	private EnemyData enemyData;

	private Transform trans;
	private Transform movepoints;
	private int currHealth;
	[SerializeField]
	private Image hpBar;

	private bool isInit = false;//fix error when Destroy() called before Initiate()


	public EnemyData EnemyData { get => enemyData; }

	void Awake()
	{
		trans = this.transform;
	}

	public void Initiate(EnemyData data)
	{
		enemyData = data;
		this.gameObject.GetComponentInChildren<MeshRenderer>().material = data.Material;
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
		GameController.Instance.Castle.GetComponent<CastleController>().GetDamage(enemyData.Damage);//player castle get damage
		Destroy(trans.gameObject);
	}

	public void GetDamage(int dmg)
	{
		if (!isInit)
			return;
		currHealth -= dmg;
		hpBar.fillAmount = (float)currHealth / (float)enemyData.StartHealth;
		if (currHealth <= 0)
			Death();
	}

	private void Death()
	{
		GameController.Instance.PlusGold(Random.Range(enemyData.MinGivenGold, enemyData.MaxGivenGold));
		Destroy(this.gameObject);
	}
}
