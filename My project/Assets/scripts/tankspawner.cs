using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankspawner : MonoBehaviour
{
    public GameObject tankPrefab; 
    public Vector3 spawnOffset = new Vector3(0, 0, 0); 

    void Start()
    {
        InvokeRepeating("SpawnTank", 0f, 5f);
    }

    void SpawnTank()
    {
        Instantiate(tankPrefab, transform.position + spawnOffset, Quaternion.identity);
    }
}
