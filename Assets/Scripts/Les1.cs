using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Les1 : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public Vector3 v;
    public GameObject P;
    public float t = 0;
    public float tmax = 0;

    // Start is called before the first frame update
    void Start()
    {
        P.transform.position = A.transform.position;
        v = B.transform.position- A.transform.position;
        Debug.Log(v.magnitude);
        v.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        P.transform.position += v * 0.5f * Time.deltaTime;
        if((B.transform.position - P.transform.position).magnitude < 0.1f)
        {
            tmax = t;
            P.transform.position = A.transform.position;
            t = 0;
        }
        
    }
}
