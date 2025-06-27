using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomtankdirection : MonoBehaviour
{
    public float speed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Generate a random direction vector
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        // Move the tank in the random direction
        transform.Translate(randomDirection * speed * Time.deltaTime);
        // Optional: Rotate the tank to face the direction it's moving
        if (randomDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }

    }
}
