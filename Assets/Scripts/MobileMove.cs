using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour {
	private Rigidbody2D rg;
	public float speed;
	public Transform _left;
	public Transform _right;
	public float ortaSpeed;
	
	private bool goingLeft = false;
	private bool goingRight = false;
	private GameManager gm;
	private Touch leftTouch;
	private Touch rightTouch;
	


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			//Add points
			gm.score++;
		}
		if (other.CompareTag("Obstacle"))
		{
			Debug.Log("Öldün çık.");
			gm.gameFinished = true;
			this.enabled = false;
			
		}
		
	}
	
	

	// Use this for initialization
	void Awake ()
	{
		this.enabled = true;
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//foreach?|| for i<2 
		foreach (var touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began) {
				// Construct a ray from the current touch coordinates
				Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x,
					Camera.main.ScreenToWorldPoint(touch.position).y);
				RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
					if (hit.collider.gameObject.CompareTag("LeftTouch"))
					{
						leftTouch = touch;
					}
					else if(hit.collider.gameObject.CompareTag("RightTouch"))
					{
						rightTouch = touch;
					}
			}
		}

//		if (Input.GetMouseButtonUp(0))
//		{
//			Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
//				Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
//			RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
//
//			if (hit)
//			{
//				Debug.Log("Mouse button released");
//				Debug.Log("Hit smthng: " + hit.transform.name);
//			}
//		}

		if (!goingLeft && !goingRight)
		{
			if (speed > 0)
				speed -= -0.11f;
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,transform.position.y), speed * Time.deltaTime);
		}

		if (leftTouch.phase != TouchPhase.Began )
		{
			Debug.Log("Left Began");

			speed = 0.5f;
			goingLeft = true;
		}

		if (leftTouch.phase == TouchPhase.Moved || leftTouch.phase == TouchPhase.Stationary )
		{
			Debug.Log("Left Moves or Waits");

			if (speed < 4)
				speed *= 1.1f;
			transform.position = Vector2.MoveTowards(transform.position, leftTouch.position, speed*Time.deltaTime);
		}
		if (leftTouch.phase == TouchPhase.Ended)
		{
			Debug.Log("Left Ended");

			speed = 0.5f;
			goingLeft = false;
		}
		if (rightTouch.phase == TouchPhase.Began)
		{
			Debug.Log("Right Began");

			speed = 0.5f;
			goingRight = true;
		}
		if (rightTouch.phase == TouchPhase.Moved || rightTouch.phase == TouchPhase.Stationary )
		{
			Debug.Log("Right Moves or Waits");

			if (speed < 4)
				speed *= 1.1f;
			transform.position = Vector2.MoveTowards(transform.position, rightTouch.position, speed*Time.deltaTime);
		}
		if (rightTouch.phase == TouchPhase.Ended)
		{
			Debug.Log("Right Ended");

			speed = 0.5f;
			goingRight = false;
		}
	}
}
