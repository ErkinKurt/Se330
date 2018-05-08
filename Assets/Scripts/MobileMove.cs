using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour
{
    public Transform _leftTransform;
    public Transform _rightTransform;
    [SerializeField]
    private float speed ;
    private float startTime;
    private Touch _touch;
    private bool isLeft = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.A)) {isLeft = true; startTime = Time.time;}
        else if (Input.GetKeyDown(KeyCode.S)){isLeft = false; startTime = Time.time;}
        */
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(_touch.position).x,
                    Camera.main.ScreenToWorldPoint(_touch.position).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                Debug.Log("Ray Position" + rayPos);
                if (hit)
                {
                    Debug.Log("HIT SMTHNG : " + hit.collider.name);
                    if (hit.collider.CompareTag("LeftSide"))
                    {
                        startTime = Time.time;
                        isLeft = true;
                    }
                    else if (hit.collider.CompareTag("RightSide"))
                    {
                        startTime = Time.time;
                        isLeft = false;
                    }
                }
            }
        }

        if (isLeft)
        {
            transform.position = Vector2.Lerp(transform.position, _leftTransform.position, (Time.time - startTime ) / 4);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, _rightTransform.position, (Time.time - startTime) /4);
        }


    }

    private void FixedUpdate()
    {
 
    }
}