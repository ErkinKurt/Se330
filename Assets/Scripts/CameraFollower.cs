using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CameraFollower : MonoBehaviour
{
	public Transform target;
	public float speed;
	public Vector3 offset;

	private void Update()
	{
		if (target.position.y + offset.y > transform.position.y)
		{
			Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
			transform.position = smoothedPosition;	
		}
	}
}
