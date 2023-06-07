using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 1, 0);
    public float speed = 1;
    UnityEngine.Vector2 minView;
    Vector2 maxView;

    void Start()
    {
        minView = Camera.main.ScreenToWorldPoint(UnityEngine.Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {



        getBounds();

        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles -= new Vector3(0, 0, 10);
            velocity = UnityEngine.Quaternion.Euler(0, 0, -10) * velocity;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.localEulerAngles += new Vector3(0, 0, 10);
            velocity = UnityEngine.Quaternion.Euler(0, 0, 10) * velocity;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) { speed--; }

    }

    void getBounds()
    {
        if (transform.position.y > maxView.y + transform.localScale.x / 2)
        {
            transform.position = new Vector3(transform.position.x, minView.y - transform.localScale.x / 2, 0);
        }

        if (transform.position.y < minView.y - transform.localScale.x / 2)
        {
            transform.position = new Vector3(transform.position.x, maxView.y + transform.localScale.x / 2, 0);
        }
        
        if(transform.position.x > maxView.x + transform.localScale.x / 2)
        {
            transform.position = new Vector3(minView.x - (transform.localScale.x / 2), 0);
        }

        if (transform.position.x < minView.x - transform.localScale.x / 2)
        {
            transform.position = new Vector3(maxView.x + (transform.localScale.x / 2), 0);
        }


    }
}
