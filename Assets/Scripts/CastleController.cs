using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
	[SerializeField]
	private int health = 100;

	public void GetDamage(int dmg)
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
