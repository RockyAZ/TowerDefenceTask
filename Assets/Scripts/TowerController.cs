using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
	private Transform trans;

	// Start is called before the first frame update
	void Start()
	{
		trans = this.transform;
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
				float tmpDist = Vector3.Distance(GameController.Instance.Enemies.GetChild(i).position, GameController.Instance.Castle.position);
				if (tmpDist < dist)
				{
					dist = tmpDist;
					id = i;
				}
			}
			if (dist < 10)
			{
				GameController.Instance.Enemies.GetChild(id).GetComponent<EnemyController>().GetDamage(1);
				yield return new WaitForSeconds(0.3f);
			}
			yield return null;
		}
	}
}
