using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePassenger : MonoBehaviour
{
    public GameObject Player;
    

     void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player = collider.gameObject;
            transform.parent = Player.transform;
            Debug.Log("Picked");

        }
    }

}
