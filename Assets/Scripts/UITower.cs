using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITower : MonoBehaviour
{
	private GameObject canvas;
	// Start is called before the first frame update
	private Button buyBtn;
	private Button sellBtn;

	private GameObject buyUI;

	void Start()
	{
		canvas = GetComponentInChildren<Canvas>().gameObject;
		if (canvas == null)
			Debug.LogError("no canvas in " + this.gameObject.name);

		this.transform.LookAt(this.transform.position - Camera.main.transform.position, Vector3.up);

		buyBtn = canvas.transform.Find("Buy").GetComponent<Button>();
		if (buyBtn == null)
			Debug.LogError("no buyBtn in " + this.gameObject.name);

		sellBtn = canvas.transform.Find("Sell").GetComponent<Button>();
		if (sellBtn == null)
			Debug.LogError("no sellBtn in " + this.gameObject.name);
	}

	public void ShowUI()
	{
		canvas.SetActive(true);
	}
	public void HideUI()
	{
		canvas.SetActive(false);
	}
}
