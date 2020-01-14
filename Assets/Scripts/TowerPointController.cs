using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPointController : MonoBehaviour
{
	private GameObject child;

	public void AddChild(TowerData towerData)
	{
		child = Instantiate(GameController.Instance.TowerPref, this.transform);
		child.GetComponent<TowerController>().Initiate(towerData);
	}

	public void DeleteChild()
	{
		Destroy(child);
	}

	public int GetChildPrice()
	{
		return child.GetComponent<TowerController>().TowerData.Price;
	}

	public bool HaveChild()
	{
		if (child == null)
			return false;
		return true;
	}

	public void SetMaterial(Material mat)
	{
		this.gameObject.GetComponent<MeshRenderer>().material = mat;
	}
}
