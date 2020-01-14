using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
	private Transform trans;
	private Camera cam;
	// Start is called before the first frame update
	void Start()
	{
		trans = this.transform;
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		trans.LookAt(cam.transform, Vector3.up);
	}
}
