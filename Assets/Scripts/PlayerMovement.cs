﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	
	private void Update()
	{
		transform.position += Vector3.up * speed * Time.deltaTime;
	}
}
