﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAdjustLeft : MonoBehaviour
{
	private float initialYPoint;
	[SerializeField]
	private float maxDistance;
	[SerializeField]
	private float speed;
	public Transform endPoint;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		initialYPoint = transform.position.y;

		Vector2 direction = endPoint.position - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg* Mathf.Atan2(direction.y,direction.x));

		if (Input.GetKey(KeyCode.Q))
		{
			if (transform.position.y - initialYPoint <= maxDistance)
			{
				transform.position += new Vector3(0, (speed*speed) * Time.deltaTime, 0);
			}
		}

		if (Input.GetKey(KeyCode.Z))
		{
			if ( transform.position.y - initialYPoint  >= -maxDistance)
			{
				transform.position += new Vector3(0, -(speed*speed)* Time.deltaTime, 0);
			}
		}
	}
}
