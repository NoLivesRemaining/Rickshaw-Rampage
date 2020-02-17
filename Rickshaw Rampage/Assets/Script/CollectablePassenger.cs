using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePassenger : MonoBehaviour
{
    public GameObject Player;
    private MeshRenderer Mesh;

    private void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player = collider.gameObject;
            transform.parent = Player.transform;
            transform.position = transform.parent.position;
            Mesh.enabled = false;
        }
    }

}
