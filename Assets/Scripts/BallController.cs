﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particleEffect;

    [SerializeField]
    private float speed = 8;

    private bool started = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.Instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)){
            rb.velocity = new Vector3(0, -25f, 0);
            GameManager.Instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.gameOver)
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameObject particleInstance = Instantiate(particleEffect, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(particleInstance, 10f);
        }
    }
}
