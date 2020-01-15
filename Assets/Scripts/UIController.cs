using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public static UIController Instance;
	[SerializeField]
	private Button startButton;
	[SerializeField]
	private Button reloadButton;
	[SerializeField]
	private TextMeshProUGUI goldText;
	[SerializeField]
	private TextMeshProUGUI HpAmount;
	[SerializeField]
	private TextMeshProUGUI waves;

	[Space]
	[SerializeField]
	private Button buyBtn;
	[SerializeField]
	private Button sellBtn;
	[SerializeField]
	private TextMeshProUGUI priceToBuy;

	[Space]
	[SerializeField]
	private GameObject towerPointMenu;
	[SerializeField]
	private TextMeshProUGUI towerPrice;
	[SerializeField]
	private TextMeshProUGUI towerName;
	[SerializeField]
	private TMP_Dropdown towersDropDown;

	private TowerPointController currentPoint;//current tower spawn point

	void Start()
	{
		if (Instance == null)
			Instance = this;
		startButton.onClick.AddListener(this.StartGame);
		reloadButton.onClick.AddListener(this.ReloadGame);
		buyBtn.onClick.AddListener(this.Buy);
		sellBtn.onClick.AddListener(this.Sell);
	}

	public void SetGold(int gold)
	{
		goldText.text = gold.ToString();
	}

	public void ShowTowerPointMenu(TowerPointController towerPoint)
	{
		towerPointMenu.SetActive(true);
		if (currentPoint != null)
			currentPoint.SetMaterial(GameController.Instance.TowerPointMat);//stop outlining spawnPoint
		currentPoint = towerPoint;
		currentPoint.SetMaterial(GameController.Instance.TowerPointOutlineMat);//start outlining spawnPoint
		if (towerPoint.HaveChild())
		{
			towerPrice.text = towerPoint.GetChildPrice().ToString();
			towerName.text = "TowerType: " + towerPoint.GetChildType();
		}
		else
		{
			towerName.text = "NoTowerHere";	
			towerPrice.text = "0";
		}
	}
	public void HideTowerPointMenu()
	{
		towerPointMenu.SetActive(false);
		if (currentPoint != null)
			currentPoint.SetMaterial(GameController.Instance.TowerPointMat);//stop outlining spawnPoint
		currentPoint = null;
	}

	private void Buy()
	{
		if (currentPoint != null)
		{
			foreach (TowerData tmp in GameController.Instance.TowerDatas)
			{
				string dropDownValue = towersDropDown.options[towersDropDown.value].text;
				if (tmp.Type == dropDownValue && tmp.Price <= GameController.Instance.Gold)
				{
					GameController.Instance.MinusGold(tmp.Price);
					currentPoint.AddChild(tmp);
					towerPrice.text = currentPoint.GetChildPrice().ToString();
					towerName.text = "TowerType: " + currentPoint.GetChildType();
				}
			}
		}
	}
	private void Sell()
	{
		if (currentPoint != null)
		{
			GameController.Instance.PlusGold(currentPoint.GetChildPrice());
			currentPoint.DeleteChild();
		}
	}

	private void StartGame()
	{
		startButton.gameObject.SetActive(false);
		GameController.Instance.StartWaves();
	}

	public void SetWaveText(int was, int all)
	{
		waves.text = "Wave: " + was.ToString() + "|" + all.ToString();
	}

	public void ChangeToBuyValue()
	{
		foreach (TowerData tmp in GameController.Instance.TowerDatas)
		{
			string dropDownValue = towersDropDown.options[towersDropDown.value].text;
			if (tmp.Type == dropDownValue && tmp.Price <= GameController.Instance.Gold)
			{
				priceToBuy.text = tmp.Price.ToString();
			}
		}
	}
	public void ReloadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SetHp(int max, int curr)
	{
		HpAmount.text = curr.ToString() + "|" + max.ToString();
	}
}
