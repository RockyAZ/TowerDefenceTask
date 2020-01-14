using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI goldText;

	[SerializeField]
	private GameObject towerPointMenu;
	[SerializeField]
	private TextMeshProUGUI towerPrice;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetGold(int gold)
	{
		goldText.text = gold.ToString();
	}

	public void ShowTowerPointMenu()
	{
		towerPointMenu.SetActive(true);
	}
	public void HideTowerPointMenu()
	{
		towerPointMenu.SetActive(false);
	}
}
