using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
	void Awake()
	{
		Vector3 tmp = Camera.main.transform.position;
		tmp.y = this.transform.position.y;

		//this.transform.LookAt(Vector3.right, Vector3.up);
		this.transform.rotation = Quaternion.LookRotation(Vector3.left);
		this.transform.rotation = Quaternion.LookRotation(this.transform.position - Camera.main.transform.position);
		//this.transform.LookAt(Camera.main.transform, Vector3.up);
	}
}
