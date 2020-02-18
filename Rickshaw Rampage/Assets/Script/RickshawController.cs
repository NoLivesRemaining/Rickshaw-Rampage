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
    private float timer;

    public bool forward;
    public bool reverse;
    public bool left;
    public bool right;
    public bool PassengerHeld;

    private GameObject cube;
    public GameObject Passenger;
    public GameObject Bystander;
    public TextMesh Text;

    private Rigidbody rb;
    private BoxCollider col;

    public PhysicMaterial PHeld;
    public PhysicMaterial Standard;

    void Start()
    {
        StartCountdown();
        Passenger.SetActive(false);
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        cube = this.gameObject;
        PassengerHeld = false;
    }

     void Update()
    {
        speedManagement();

        rb.AddForce(transform.forward * acceleration);
        cube.transform.Rotate(0, torque, 0, Space.Self);
   

        if (PassengerHeld == true)
        {
            Passenger.SetActive(true);
            col.material = PHeld;
        }
        else
        {
            timer = Random.Range(10f, 30f);
            Passenger.SetActive(false);
            col.material = Standard;
        }
       
        if(timer == 0)
        {
            PassengerHeld = false;
            Instantiate(Bystander, cube.transform.position, cube.transform.rotation);
        }

        if(timer <= 0)
        {
            timer = 0;
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

    void StartCountdown()
    {
        if (Text.text != null)
        {
            timer = 15f;
            Text.text = "00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (Text != null)
        {
            timer -= Time.deltaTime;
            string seconds = (timer % 60).ToString("00");
            Text.text = seconds;
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
