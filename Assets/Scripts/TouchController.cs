using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
	void Update()
	{
		Ray ray = new Ray();

#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//2nd part - check if UI hitted
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		else
			return;
#else
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		else
			return;
#endif
		RaycastHit hit;
		int layer = 1 << LayerMask.NameToLayer("TowerPoint");
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
			UIController.Instance.ShowTowerPointMenu(hit.transform.GetComponent<TowerPointController>());
		else
			UIController.Instance.HideTowerPointMenu();
	}
}
