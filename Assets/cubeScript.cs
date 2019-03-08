﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    int n = 33;
    Vector3 v = new Vector3(33 / 2, 0, 33 / 2);
   public Vector3 vertical = new Vector3(0, .3f, 0);
    
    public Material material1,material2,material3,material4,material5,material6;
    public GameObject light;
    public float zoom;
    public float speed;
    Vector3 center = new Vector3(33 / 2, 0, 33 / 2);
    static float layer = 1;
    int[,] T = new int[33,33]{
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };
    int[,] Q = new int[33, 33]{
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
       {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 add = new Vector3(0, 20, 0);
        transform.RotateAround(v, Vector3.up, 10 * Time.deltaTime);
        light.transform.position = transform.position + add;
        light.transform.rotation = transform.rotation;
        GameObject cube;
        Rigidbody cubeBody;

        if (Input.GetKey("left"))
        {
            transform.RotateAround(v, Vector3.up, -40 * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.RotateAround(v, Vector3.up, 20 * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 20, Space.Self);
        }
        if (Input.GetKey("up"))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * -20, Space.Self);
        }
        if (Input.GetKey("w"))
        {
            transform.position -= zoom * (transform.position - center);
            
        }
        if (Input.GetKey("s"))
        {
            transform.position += zoom * (transform.position - center);
        }
        if (Input.GetKey("d"))
        {

            transform.Translate(vertical, Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Translate(-vertical, Space.World);
        }
        if (Time.time >= layer && Time.time < layer + Time.deltaTime)
        {
            int a = Random.Range(1, 7);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (T[i, j] == 1)
                    {
                        
                        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(i, 0, j);
                        cube.transform.localScale = new Vector3(.9f,.9f,.9f);
                        cubeBody = cube.AddComponent<Rigidbody>();
                        cubeBody.detectCollisions = false;
                        cubeBody.velocity = new Vector3(0, speed, 0);
                        
                        cubeBody.useGravity = false;
                        if (i*j<=90) { cube.GetComponent<Renderer>().material = material1; }
                        if (i*j>90&&i*j<=200) { cube.GetComponent<Renderer>().material = material2; }
                        if (i*j>200&& i*j<=400) { cube.GetComponent<Renderer>().material = material3; }
                        if (i*j>400&&i*j<=600) { cube.GetComponent<Renderer>().material = material4; }
                        if (i*j>600&&i*j<=805) { cube.GetComponent<Renderer>().material = material5; }
                        if (i*j>805) { cube.GetComponent<Renderer>().material = material6; }
                    }
                }
            }
            layer +=1/speed;
            int count;

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    count = 0;
                    if (T[i, j + 1] == 1) { count++; }
                    if (T[i, j - 1] == 1) { count++; }
                    if (T[i + 1, j + 1] == 1) { count++; }
                    if (T[i + 1, j - 1] == 1) { count++; }
                    if (T[i - 1, j + 1] == 1) { count++; }
                    if (T[i - 1, j - 1] == 1) { count++; }
                    if (T[i - 1, j] == 1) { count++; }
                    if (T[i + 1, j] == 1) { count++; }

                    if (T[i, j] == 0)
                    {
                        if (count == 3)
                        {
                            Q[i, j] = 1;
                        }
                        else
                        {
                            Q[i, j] = 0;
                        }

                    }
                    else
                    {
                        if (count == 2 || count == 3)
                        {
                            Q[i, j] = 1;
                        }
                        else
                        {
                            Q[i, j] = 0;
                        }
                    }

                }
            }

            for (int i = 1; i < n - 1; i++)//j=0
            {
                count = 0;
                if (T[i + 1, 0] == 1) { count++; }
                if (T[i - 1, 0] == 1) { count++; }
                if (T[i + 1, 1] == 1) { count++; }
                if (T[i - 1, 1] == 1) { count++; }
                if (T[i, 1] == 1) { count++; }

                if (T[i, 0] == 0)
                {
                    if (count == 3)
                    {
                        Q[i, 0] = 1;
                    }
                    else
                    {
                        Q[i, 0] = 0;
                    }

                }
                else
                {
                    if (count == 2 || count == 3)
                    {
                        Q[i, 0] = 1;
                    }
                    else
                    {
                        Q[i, 0] = 0;
                    }
                }
            }
            for (int i = 1; i < n - 1; i++)//j=n-1
            {
                int j = n - 1;
                count = 0;
                if (T[i + 1, j] == 1) { count++; }
                if (T[i - 1, j] == 1) { count++; }
                if (T[i + 1, j - 1] == 1) { count++; }
                if (T[i - 1, j - 1] == 1) { count++; }
                if (T[i, j - 1] == 1) { count++; }

                if (T[i, j] == 0)
                {
                    if (count == 3)
                    {
                        Q[i, j] = 1;
                    }
                    else
                    {
                        Q[i, j] = 0;
                    }

                }
                else
                {
                    if (count == 2 || count == 3)
                    {
                        Q[i, j] = 1;
                    }
                    else
                    {
                        Q[i, j] = 0;
                    }
                }
            }

            //column

            for (int i = 1; i < n - 1; i++)//j=0
            {
                count = 0;
                if (T[0, i + 1] == 1) { count++; }
                if (T[0, i - 1] == 1) { count++; }
                if (T[1, i + 1] == 1) { count++; }
                if (T[1, i - 1] == 1) { count++; }
                if (T[1, i] == 1) { count++; }

                if (T[0, i] == 0)
                {
                    if (count == 3)
                    {
                        Q[0, i] = 1;
                    }
                    else
                    {
                        Q[0, i] = 0;
                    }

                }
                else
                {
                    if (count == 2 || count == 3)
                    {
                        Q[0, i] = 1;
                    }
                    else
                    {
                        Q[0, i] = 0;
                    }
                }
            }
            for (int i = 1; i < n - 1; i++)//j=n-1
            {
                int j = n - 1;
                count = 0;
                if (T[j, i + 1] == 1) { count++; }
                if (T[j, i - 1] == 1) { count++; }
                if (T[j - 1, i + 1] == 1) { count++; }
                if (T[j - 1, i - 1] == 1) { count++; }
                if (T[j - 1, i] == 1) { count++; }

                if (T[j, i] == 0)
                {
                    if (count == 3)
                    {
                        Q[j, i] = 1;
                    }
                    else
                    {
                        Q[j, i] = 0;
                    }

                }
                else
                {
                    if (count == 2 || count == 3)
                    {
                        Q[j, i] = 1;
                    }
                    else
                    {
                        Q[j, i] = 0;
                    }
                }
            }

            count = 0;//T[0,0}
            if (T[0, 1] == 1) { count++; }
            if (T[1, 1] == 1) { count++; }
            if (T[1, 0] == 1) { count++; }
            if (T[0, 0] == 0)
            {
                if (count == 3) { Q[0, 0] = 1; }
                else
                {
                    Q[0, 0] = 0;
                }
            }
            else
            {
                if (count == 2 || count == 3)
                {
                    Q[0, 0] = 1;
                }
                else
                {
                    Q[0, 0] = 0;
                }
            }
            count = 0;//T[0,n-1]
            if (T[0, n - 2] == 1) { count++; }
            if (T[1, n - 1] == 1) { count++; }
            if (T[1, n - 2] == 1) { count++; }
            if (T[0, n - 1] == 0)
            {
                if (count == 3) { Q[0, n - 1] = 1; }
                else
                {
                    Q[0, n-1] = 0;
                }
            }
            else
            {
                if (count == 2 || count == 3)
                {
                    Q[0, n - 1] = 1;
                }
                else
                {
                    Q[0, n - 1] = 0;
                }
            }
            count = 0;//T[n-1,0]
            if (T[n - 2, 0] == 1) { count++; }
            if (T[n - 2, 1] == 1) { count++; }
            if (T[n - 1, 1] == 1) { count++; }
            if (T[n - 1, 0] == 0)
            {
                if (count == 3) { Q[n - 1, 0] = 1; }
                else
                {
                    Q[n-1, 0] = 0;
                }
            }
            else
            {
                if (count == 2 || count == 3)
                {
                    Q[n - 1, 0] = 1;
                }
                else
                {
                    Q[n - 1, 0] = 0;
                }
            }
            count = 0;//T[n-1,n-1]
            if (T[n - 2, n - 2] == 1) { count++; }
            if (T[n - 2, n - 1] == 1) { count++; }
            if (T[n - 1, n - 2] == 1) { count++; }
            if (T[n - 1, n - 1] == 0)
            {
                if (count == 3) { Q[n - 1, n - 1] = 1; }
                else
                {
                    Q[n-1, n-1] = 0;
                }
            }
            else
            {
                if (count == 2 || count == 3)
                {
                    Q[n - 1, n - 1] = 1;
                }
                else
                {
                    Q[n - 1, n - 1] = 0;
                }
            }

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    T[i, j] = Q[i, j];
                }
            }


        }
    }
}
