using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePassenger : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            Player = collider.gameObject;
            if (Player.GetComponent<RickshawController>().PassengerHeld == false)
            {

                Player.GetComponent<RickshawController>().PassengerHeld = true;
                Destroy(gameObject);
            }

        }

        if (collider.gameObject.tag == "Player2")
        {
            Player = collider.gameObject;

            if (Player.GetComponent<RickshawController2>().PassengerHeld == false)
            {
                Player.GetComponent<RickshawController2>().PassengerHeld = true;
                Destroy(gameObject);
            }

        }
    }

}
