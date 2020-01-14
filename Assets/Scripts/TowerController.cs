using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
	[SerializeField]
	private TowerData towerData;

	private Transform trans;
	private LineRenderer line;

	// Start is called before the first frame update
	void Start()
	{
		trans = this.transform;
		line = this.GetComponent<LineRenderer>();
		Instantiate(towerData.Model, trans);
		StartCoroutine(Attack());
	}

	IEnumerator Attack()
	{
		while (true)
		{
			List<Transform> inRange = new List<Transform>();
			float dist = Mathf.Infinity;
			int id = -1;

			//find all enemies in tower attack range
			for (int i = 0; i < GameController.Instance.Enemies.childCount; i++)
				if (Vector3.Distance(trans.position, GameController.Instance.Enemies.GetChild(i).position) <= towerData.Range)
					inRange.Add(GameController.Instance.Enemies.GetChild(i));

			//find closest enemy to the player castle.
			for (int i = 0; i < inRange.Count; i++)
			{
				float tmpDist = Vector3.Distance(inRange[i].position, GameController.Instance.Castle.position);
				if (tmpDist < dist)
				{
					dist = tmpDist;
					id = i;
				}
			}

			//do action with enemy if found
			if (id >= 0)
			{
				Transform enemy = inRange[id];
				trans.LookAt(enemy, Vector3.up);
				enemy.GetComponent<EnemyController>().GetDamage(1);
				StartCoroutine(DrawLine(enemy.position));
				yield return new WaitForSeconds(towerData.Interval);
			}
			yield return null;
		}
	}

	IEnumerator DrawLine(Vector3 dest)
	{
		line.positionCount = 2;
		line.SetPosition(0, trans.position);
		line.SetPosition(1, dest);
		yield return new WaitForSeconds(0.05f);
		line.positionCount = 1;
	}
}
