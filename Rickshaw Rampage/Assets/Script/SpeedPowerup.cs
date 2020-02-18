using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    private SpriteRenderer Mesh;
    private BoxCollider BCollider;
    public GameObject Player;

    public bool coolingDown;
    public bool P1isBoosted = false;
    public bool P2isBoosted = false;
    public float respawnTimer;
    public float speedCoolDown;
    public float speedUpMultiplier;

    void Start()
    {
        Mesh = GetComponent<SpriteRenderer>();
        BCollider = GetComponent<BoxCollider>();
        respawnTimer = 1000f;
    }

    void Update()
    {
        respawnTimer++;
       

        if (respawnTimer >= 1000f)
        {
            RespawnPickup();
        }

        if(coolingDown == true)
        {
            speedCoolDown -= Time.deltaTime;
        }

        if (speedCoolDown <= 0)
        {
            speedCoolDown = 0;
        }

        if (P1isBoosted == false && speedCoolDown == 0)
        {
            speedUpMultiplier = 1;
            coolingDown = false;
            Player = null;
        }

        if (P2isBoosted == false && speedCoolDown == 0)
        {
            speedUpMultiplier = 1;
            coolingDown = false;
            Player = null;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            Player = collider.gameObject;
            P1isBoosted = true;
            speedUpMultiplier = 4f;
            speedCoolDown = 4f;
            coolingDown = true;
            Player.GetComponent<RickshawController>().boost = speedUpMultiplier;
            Invoke("SetBoolBack", 5);
            Mesh.enabled = false;
            BCollider.enabled = false;
            respawnTimer = 0f;
        }

        if (collider.gameObject.tag == "Player2")
        {
            Player = collider.gameObject;
            P2isBoosted = true;
            speedUpMultiplier = 4;
            speedCoolDown = 4f;
            coolingDown = true;
            Player.GetComponent<RickshawController2>().boost = speedUpMultiplier;
            Invoke("SetBoolBack", 5);
            Mesh.enabled = false;
            BCollider.enabled = false;
            respawnTimer = 0f;
        }
    }

    

    void RespawnPickup()
    {
        Mesh.enabled = true;
        BCollider.enabled = true;
    }

    void SetBoolBack()
    {
        P1isBoosted = false;
        P2isBoosted = false;
    }
}
