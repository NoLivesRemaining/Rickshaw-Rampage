using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickshawController : MonoBehaviour
{
    public float acceleration;
    public float torque;
    public float maxForward = 14;
    public float maxReverse = -14;
    public float maxTorqueRight = 2;
    public float maxTorqueLeft = -2;
    // Speed Powerup multiplier float
    public float speedUpMultiplier;
    public bool forward;
    public bool reverse;
    public bool left;
    public bool right;

    public bool PassengerHeld;

    private Rigidbody rb;
    private GameObject cube;

    // referencing SpeedPowerup script so that the bool can be pulled from it
    public SpeedPowerup speedPowerup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cube = this.gameObject;
        PassengerHeld = false;
    }

     void Update()
    {
        speedManagement();

        // added Speed Powerup multiplier to acceleration
        rb.AddForce(transform.forward * acceleration * speedUpMultiplier);

        if (PassengerHeld == true)
        {

        }
        else
        {
            cube.transform.Rotate(0, torque, 0, Space.Self);
        }
       
        // taking bool from SpeedPowerup script and using IF statement to check if Speed Powerup is active, and assigning values for both results
        if(speedPowerup.isBoosted)
        {
            speedUpMultiplier = 2;
        }
        else
        {
            speedUpMultiplier = 1;
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(acceleration > maxForward)
            {
                acceleration = maxForward;
            }
            else
            {
                acceleration += 0.1f;
            }
              forward = true;
        }

        if (Input.GetKey(KeyCode.S))
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

        if (Input.GetKey(KeyCode.A))
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

        if (Input.GetKey(KeyCode.D))
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

        if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            reverse = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && acceleration < 0)
        {
            acceleration += 10f;
        }

        if (Input.GetKeyDown(KeyCode.S) && acceleration > 0)
        {
            acceleration -= 10f;
        }
    }
}
