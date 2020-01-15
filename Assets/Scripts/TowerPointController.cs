using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPointController : MonoBehaviour
{
	private GameObject child;

	public void AddChild(TowerData towerData)
	{
		if (child != null)
		{
			GameController.Instance.PlusGold(child.GetComponent<TowerController>().TowerData.Price);
			Destroy(child);
		}
		child = Instantiate(GameController.Instance.TowerPref, this.transform);
		child.GetComponent<TowerController>().Initiate(towerData);
	}

	public void DeleteChild()
	{
		if (child != null)
			Destroy(child);
	}

	public int GetChildPrice()
	{
		return child.GetComponent<TowerController>().TowerData.Price;
	}
	public string GetChildType()
	{
		return child.GetComponent<TowerController>().TowerData.Type;

	}
	public bool HaveChild()
	{
		if (child == null)
			return false;
		return true;
	}

	public void SetMaterial(Material mat)
	{
		this.gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
	}
}
