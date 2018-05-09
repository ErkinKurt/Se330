using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour
{
    public Transform _leftTransform;
    public Transform _rightTransform;
    public ObstacleSpawner obs;
    [SerializeField] private float speed;
    private float startTime;
    private Touch _touch;
    private bool isLeft = false;
    private float coinTime;
    private bool AteCoin = false;
    private GameManager gm;
    


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinTime = Time.time;
            AteCoin = true;
            transform.position = Vector2.MoveTowards(transform.position,other.transform.position,speed/4) ;
            other.gameObject.SetActive(false);
            gm.score++;
        }

        if (other.CompareTag("Obstacle"))
        {
            coinTime = Time.time;
            gm.gameFinished = true;
            this.enabled = false;
        }
    }

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AteCoin)
        {
            Debug.Log("Obstacle spawn interval: "+obs.spawnInterval * 0.2f);
            if (Time.time - coinTime > obs.spawnInterval * 0.2f)
            {
                AteCoin = false;
                startTime = Time.time;
            }
        }
        else
        {
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
                transform.position =
                    Vector2.Lerp(transform.position, _leftTransform.position, (Time.time - startTime) / 4);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, _rightTransform.position,
                    (Time.time - startTime) / 4);
            }
        }
    }

    private void FixedUpdate()
    {
    }
}