using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            Player = collider.gameObject;
            Player.GetComponent<Rigidbody>().AddTorque(0, 100000, 0);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Player2")
        {
            Player = collider.gameObject;

        }
    }
}
