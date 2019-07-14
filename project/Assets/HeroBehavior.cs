using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroBehavior : MonoBehaviour
{

    public float speed;
    private double theta = 0;
    private double r = 4;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        if (Input.GetKey("up"))
        {
            print("up");
            moveVertical = 10.0f;
        }
        if (Input.GetKey("down"))
        {
            print("down");
            moveVertical = -10.0f;
        }
        if (Input.GetKey("left"))
        {
            print("left");
            //moveHorizontal = -10.0f;
            theta += 0.01f;
        }
        if (Input.GetKey("right"))
        {
            print("right");
            //moveHorizontal = 10.0f;
            theta -= 0.01f;
        }

        if (Input.GetKeyDown("space"))
        {
            //Texture2D t = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Sprites/mario_stand.png", typeof(Texture2D));
            //renderer.material.mainTexture = t;
            print("space key was pressed");
            moveVertical = -10.0f;
        }

        Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);
        rb.AddForce(movement * speed);
        rb.position = new Vector3((float)(r*Math.Cos(theta)), 0.0f, (float)(r*Math.Sin(theta)));
    }

    // Update is called once per frame
    void Update()
    {

        //lookat camera
        transform.LookAt(gameObject.transform.position);
    }
}
