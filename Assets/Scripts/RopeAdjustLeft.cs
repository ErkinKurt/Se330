using System.Collections;
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
		initialYPoint = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 direction = endPoint.position - transform.position;
		transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg* Mathf.Atan2(direction.y,direction.x));

		if (Input.GetKey(KeyCode.Q))
		{
			if (transform.position.y - initialYPoint <= maxDistance)
			{
				transform.position += new Vector3(0, speed * Time.deltaTime, 0);
			}
		}

		if (Input.GetKey(KeyCode.Z))
		{
			if ( transform.position.y - initialYPoint  >= -maxDistance)
			{
				transform.position += new Vector3(0, -speed* Time.deltaTime, 0);
			}
		}
	}
}
