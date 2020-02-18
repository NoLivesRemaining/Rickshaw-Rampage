using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public GameObject PassengerPrefab;
    public GameObject[] spawnPoints;
    private GameObject currentSpawn;

    public int NumberOfPassengers;
    public int DesiredNumberOfPassengers;
    private int index;

    public float countdownToSpawn;
    public float countdownReset;

    private void Start()
    {
        DesiredNumberOfPassengers = 4;
        countdownReset = 10f;
    }

    void Update()
    {
        countdownToSpawn -= Time.deltaTime;
        NumberOfPassengers = GameObject.FindGameObjectsWithTag("Passenger").Length;

        if (countdownToSpawn <= 0)
        {
            countdownToSpawn = 0;
        }

        if(countdownToSpawn == 0)
        {
            Spawn();
            countdownToSpawn = countdownReset;
        }
    }

    void Spawn()
    {
        if(NumberOfPassengers < DesiredNumberOfPassengers)
        {
            index = Random.Range(0, spawnPoints.Length);
            currentSpawn = spawnPoints[index];
            Instantiate(PassengerPrefab, currentSpawn.transform.position, transform.rotation);
        }
    }
}
