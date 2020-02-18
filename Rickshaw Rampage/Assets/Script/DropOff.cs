using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bystander;
    public GameTimeScript Score;

    private bool startDelay1;
    private bool startDelay2;
    public float delay1 = 0.5f;
    public float delay2 = 0.5f;
    private float resetDelay = 0.5f;

    private void Update()
    {
        if (startDelay1 == true)
        {
            delay1 -= Time.deltaTime;
        }

        if (delay1 <= 0)
        {
            delay1 = 0;
        }

        if (startDelay2 == true)
        {
            delay2 -= Time.deltaTime;
        }

        if (delay2 <= 0)
        {
            delay2 = 0;
        }

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            Player = collider.gameObject;
            if (Player.GetComponent<RickshawController>().PassengerHeld == true)
            {
                startDelay1 = true;

                if (delay1 == 0)
                {
                    Instantiate(Bystander, new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z), Player.transform.rotation);
                    startDelay1 = false;
                    delay1 = resetDelay;
                    Score.Player1Score++;
                    Player.GetComponent<RickshawController>().PassengerHeld = false;

                }
            }
            Player = null;
        }

        if (collider.gameObject.tag == "Player2")
        {
            Player = collider.gameObject;
            if (Player.GetComponent<RickshawController>().PassengerHeld == true)
            {
                startDelay2 = true;

                if (delay2 == 0)
                {
                    Instantiate(Bystander, new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z), Player.transform.rotation);
                    startDelay2 = false;
                    delay2 = resetDelay;
                    Score.Player2Score++;
                    Player.GetComponent<RickshawController>().PassengerHeld = false;

                }
            }
            Player = null;
        }
    }
}
