using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rg;
	public float speed;
	public Transform _left;
	public Transform _right;

	private bool goingLeft = false;
	private bool goingRight = false;
	
	// Use this for initialization
	void Start ()
	{
		rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		rg.velocity = Vector2.zero;
		if (!goingLeft && !goingRight)
		{
			//Vector2 center = (_left.position - _right.position )/2;
			//transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,transform.position.y), speed );
			//rg.velocity = new Vector2(0, transform.position.y);
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			goingLeft = true;
		}

		if (Input.GetKey(KeyCode.A))
		{
			//transform.position = Vector2.MoveTowards(transform.position, _left.position,speed) ;
			rg.velocity = Vector2.left;

		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			rg.velocity = Vector2.zero;
			goingLeft = false;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			goingRight = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			rg.velocity = Vector2.right;
			//transform.position = Vector2.MoveTowards(transform.position, _right.position, speed);
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			rg.velocity = Vector2.zero;
			goingRight = false;
		}
	}
}
