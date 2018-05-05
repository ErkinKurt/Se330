using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSc : MonoBehaviour
{
	private LineRenderer LR;
	public Transform left;
	public Transform right;
	
	
	// Use this for initialization
	void Start ()
	{
		LR = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 end1 = left.position;
		Vector3 end2 = right.position;
		LR.SetPosition(0,end1);
		LR.SetPosition(1,end2);
	}
}
