using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickshawController2 : MonoBehaviour
{
    public float acceleration;
    public float torque;
    public float maxForward = 14;
    public float maxReverse = -14;
    public float maxTorqueRight = 2;
    public float maxTorqueLeft = -2;
    public bool forward;
    public bool reverse;
    public bool left;
    public bool right;
    private Rigidbody rb;
    private GameObject cube;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cube = this.gameObject;
    }

    void Update()
    {
        speedManagement();

        rb.AddForce(transform.forward * acceleration);

        cube.transform.Rotate(0, torque, 0, Space.Self);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (acceleration > maxForward)
            {
                acceleration = maxForward;
            }
            else
            {
                acceleration += 0.1f;
            }
            forward = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (acceleration < maxReverse)
            {
                acceleration = maxReverse;
            }
            else
            {
                acceleration -= 0.1f;
            }
            reverse = true;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (torque < maxTorqueLeft)
            {
                torque = maxTorqueLeft;
            }
            else
            {
                torque -= 0.1f;
            }
            left = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (torque > maxTorqueRight)
            {
                torque = maxTorqueRight;
            }
            else
            {
                torque += 0.1f;
            }
            right = true;
        }
    }

    void speedManagement()
    {
        if (torque > 0 && right == false)
        {
            torque = 0;
        }

        if (torque < 0 && left == false)
        {
            torque = 0;
        }

        if (torque == 0)
        {
            torque = 0;
        }

        if (acceleration > 0 && forward == false)
        {
            acceleration -= Time.deltaTime * 2;
        }

        if (acceleration < 0 && reverse == false)
        {
            acceleration += Time.deltaTime * 2;
        }

        if (acceleration == 0)
        {
            acceleration = 0;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            forward = false;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            reverse = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && acceleration < 0)
        {
            acceleration += 10f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && acceleration > 0)
        {
            acceleration -= 10f;
        }
    }
}
