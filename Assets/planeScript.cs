using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 8, 0);
    }
}
