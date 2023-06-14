using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 1, 0);
    public float speed = 1.0f;

    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }
}
