using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    float time = 0;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 60)
        {
            Destroy(gameObject);
        }
        t.position = t.position - Vector3.down * Time.deltaTime*8;
    }
}
