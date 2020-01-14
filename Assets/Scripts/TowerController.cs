using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
	private Transform trans;
	private LineRenderer line;

	// Start is called before the first frame update
	void Start()
	{
		trans = this.transform;
		line = this.GetComponent<LineRenderer>();
		StartCoroutine(Attack());
	}

	// Update is called once per frame
	void Update()
	{
	}

	IEnumerator Attack()
	{
		while (true)
		{
			float dist = Mathf.Infinity;
			int id = 0;
			for (int i = 0; i < GameController.Instance.Enemies.childCount; i++)
			{
				//closest enemy to the player castle.
				float tmpDist = Vector3.Distance(GameController.Instance.Enemies.GetChild(i).position, GameController.Instance.Castle.position);
				if (tmpDist < dist)
				{
					dist = tmpDist;
					id = i;
				}
			}
			//new distance between this tower and chosen enemy
			dist = Vector3.Distance(trans.position, GameController.Instance.Enemies.GetChild(id).position);
			Transform enemy = GameController.Instance.Enemies.GetChild(id);
			if (dist < 10)
			{
				trans.LookAt(enemy, Vector3.up);
				enemy.GetComponent<EnemyController>().GetDamage(1);
				StartCoroutine(DrawLine(enemy.position));
				yield return new WaitForSeconds(0.5f);
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
