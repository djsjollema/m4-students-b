using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PongGame : MonoBehaviour
{
    public GameObject pongBall;
    public Vector3 velocity = new Vector3(-1,2,0);
    public GameObject playerA;

    Vector2 maxView;
    Vector2 minView;

    public TMP_Text Ascore;
    public TMP_Text BScore;


    RaycastHit2D hit;

    void Start()
    {
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        //Debug.Log(maxView);
        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        //Debug.Log(minView);
        Ascore.text = "doei";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            playerA.transform.position += new Vector3(0, 1, 0) * 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerA.transform.position += new Vector3(0, -1, 0);

        }

        pongBall.transform.position += velocity * Time.deltaTime; 

        hit = Physics2D.Raycast(pongBall.transform.position,new Vector3(velocity.x,0,0), pongBall.transform.localScale.x/2);
        if(hit.collider != null)
        {
            velocity = new Vector3(-velocity.x, velocity.y, 0);

        }
        
        if(pongBall.transform.position.y > maxView.y - pongBall.transform.localScale.x/2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }

        if(pongBall.transform.position.y < minView.y + pongBall.transform.localScale.x / 2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }

        if(pongBall.transform.position.x > maxView.x + pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = new Vector3(0, 0, 0);
        }
        
        if(pongBall.transform.position.x < minView.x - pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
        }
    }
}
