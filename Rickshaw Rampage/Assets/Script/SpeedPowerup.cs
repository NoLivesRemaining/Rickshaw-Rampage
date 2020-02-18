using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    private MeshRenderer Mesh;
    private BoxCollider BCollider;

    public bool isBoosted = false;
    public float respawnTimer = 0f;

    void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
        BCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        respawnTimer++;

        if (respawnTimer >= 1000f)
        {
            RespawnPickup();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isBoosted = true;
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
        isBoosted = false;
    }
}
