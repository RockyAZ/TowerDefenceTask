using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
	[SerializeField]
	private int startHealth = 100;
	private int currentHealth;
	private bool dead = false;

	public int StartHealth { get => startHealth; }
	public int CurrentHealth { get => currentHealth; }

	private void Start()
	{
		currentHealth = startHealth;
		UIController.Instance.SetHp(startHealth, currentHealth);
	}

	public void GetDamage(int dmg)
	{
		if (dead)
			return;
		currentHealth -= dmg;
		UIController.Instance.SetHp(startHealth, currentHealth);
		if (currentHealth <= 0)
			Death();
	}

	private void Death()
	{
		GameController.Instance.GameOver();
		dead = true;
	}
}
