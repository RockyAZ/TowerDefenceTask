using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public static UIController Instance;
	[SerializeField]
	private TextMeshProUGUI goldText;

	[SerializeField]
	private GameObject towerPointMenu;
	[SerializeField]
	private Button buyBtn;
	[SerializeField]
	private Button sellBtn;
	[SerializeField]
	private TextMeshProUGUI towerPrice;
	[SerializeField]
	private TMP_Dropdown towersDropDown;

	private TowerPointController currentPoint;//current tower spawn point

	void Start()
	{
		if (Instance == null)
			Instance = this;
		buyBtn.onClick.AddListener(Buy);
		sellBtn.onClick.AddListener(Sell);
	}

	public void SetGold(int gold)
	{
		goldText.text = gold.ToString();
	}

	public void ShowTowerPointMenu(TowerPointController towerPoint)
	{
		towerPointMenu.SetActive(true);
		currentPoint = towerPoint;
		if (towerPoint.HaveChild())
			towerPrice.text = towerPoint.GetChildPrice().ToString();
		else
			towerPrice.text = "0";
	}
	public void HideTowerPointMenu()
	{
		towerPointMenu.SetActive(false);
		currentPoint = null;
	}

	public void Buy()
	{
		print("buy");
		if (currentPoint != null)
		{
			print("buy_inside");
			foreach (TowerData tmp in GameController.Instance.TowerDatas)
			{
				string dropDownValue = towersDropDown.options[towersDropDown.value].text;
				if (tmp.Type == dropDownValue && tmp.Price <= GameController.Instance.Gold)
				{
					GameController.Instance.MinusGold(tmp.Price);
					currentPoint.AddChild(tmp);
				}
			}
		}
	}
	public void Sell()
	{
		if (currentPoint != null)
		{
			GameController.Instance.PlusGold(currentPoint.GetChildPrice());
			currentPoint.DeleteChild();
		}
	}
}
