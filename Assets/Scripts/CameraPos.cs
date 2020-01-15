using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
	[SerializeField]
	Transform leftCorner;
	[SerializeField]
	Transform rightCorner;
	[Range(0, 180)]
	public float tng;

	//set camera position to catch all in game scene
	//tan(a/2) = (s/2) / d => d = (s/2) / tan(a/2)
	void Start()
	{
		print("tng: " + Mathf.Tan(tng) * Mathf.Rad2Deg);

		var radAngle = Camera.main.fieldOfView * Mathf.Deg2Rad;
		var radHFOV = 2 * Mathf.Atan(Mathf.Tan(radAngle / 2) * Camera.main.aspect);
		//var hFOV = Mathf.Rad2Deg * radHFOV;

		float calcFov = radHFOV/* * Mathf.Rad2Deg*/;
		float distanceBetween = Vector3.Distance(leftCorner.position, rightCorner.position);
		float d = (distanceBetween / 2) / Mathf.Tan(((calcFov / 2)));

		Camera.main.transform.position = -Camera.main.transform.forward.normalized * Mathf.Abs(d);
	}
}
