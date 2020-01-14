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

	public EnemyData EnemyData { get => enemyData; set => enemyData = value; }

	// Start is called before the first frame update
	void Awake()
	{
		print("ss: " + enemyData.StartHealth);

		trans = this.transform;

		GameObject tmp = Instantiate(enemyData.Model, trans);
		print("type_" + EnemyData.Type);
		print("scale_" + EnemyData.Scale);
		print("before_scale_" + tmp.transform.localScale);
		tmp.transform.localScale *= EnemyData.Scale;
		print("after_scale_" + tmp.transform.localScale);
		currHealth = enemyData.StartHealth;

		if (enemyData == null)
			Debug.LogWarning("No enemyData in" + this.trans.name);
	}

	private void Start()
	{
		//save handling from start(all variables GameController determine in awake)
		movepoints = GameController.Instance.MovePoints;
		StartCoroutine(Movement());
	}

	IEnumerator Movement()
	{
		foreach (Transform currentPoint in movepoints)
		{
			while (Vector3.Distance(trans.position, currentPoint.position) > enemyData.SwitchDist)
			{
				Vector3 tmp = Vector3.MoveTowards(trans.position, currentPoint.position, enemyData.Speed * Time.deltaTime);
				tmp.y = trans.position.y;
				trans.position = tmp;
				yield return null;
			}
		}
		//PlayerCastleGetDamageHere();
		Destroy(trans.gameObject);
	}

	public void GetDamage(int dmg)
	{
		currHealth -= dmg;
		if (currHealth <= 0)
			Death();
	}

	private void Death()
	{
		Destroy(this.gameObject);
	}
}
