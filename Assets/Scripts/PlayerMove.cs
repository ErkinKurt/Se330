using System.Collections;
using System.Collections.Generic;
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


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			//Add points
		}
		if (other.CompareTag("Obstacle"))
		{
			Debug.Log("Öldün çık.");
		}
		
	}

	// Use this for initialization
	void Start ()
	{
		rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!goingLeft && !goingRight)
		{
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,transform.position.y), speed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			goingLeft = true;
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position = Vector2.MoveTowards(transform.position, _left.position, speed*Time.deltaTime);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			goingLeft = false;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			goingRight = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position = Vector2.MoveTowards(transform.position, _right.position, speed*Time.deltaTime);
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			goingRight = false;
		}
	}
}
