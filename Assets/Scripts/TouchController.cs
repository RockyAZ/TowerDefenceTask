using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		print("fuck");
	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = new Ray();

#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		else
			return;
#else
		if (Input.touchCount > 0)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		else
			return;
#endif
		RaycastHit hit;
		int layer = 1 << LayerMask.NameToLayer("TowerPoint");
		if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
		{
			print(hit.transform.name);
		}

	}
}
