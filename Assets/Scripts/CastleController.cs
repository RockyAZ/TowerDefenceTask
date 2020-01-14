using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
	[SerializeField]
	private int health = 100;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
			GetDamage(other.GetComponent<EnemyController>().EnemyData.Damage);
	}

	private void GetDamage(int dmg)
	{
		health -= dmg;
		if (health <= 0)
			Death();
	}

	private void Death()
	{
		GameController.Instance.GameOver();
	}
}
