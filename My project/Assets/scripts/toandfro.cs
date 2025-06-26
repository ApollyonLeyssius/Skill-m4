using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toandfro : MonoBehaviour
{
    public Transform pointA;        // GameObject A
    public Transform pointB;        // GameObject B
    public Transform player;        // Player

    public float speed = 1f;        // Snelheid in meter per seconde

    private Vector3 direction;      // Richting van beweging
    private float distance;         // Afstand tussen A en B
    private float duration;         // Tijd die het kost om van A naar B te gaan
    private float timer = 0f;       // Stopwatch timer
    private bool fromAToB = true;  

    void Start()
    {
        player.position = pointA.position;

        Vector3 differenceVectorAB = pointB.position - pointA.position;
        Debug.Log("Difference Vector AB: " + differenceVectorAB);

        distance = differenceVectorAB.magnitude;
        Debug.Log("Distance AB: " + distance);

        duration = distance / speed;
        Debug.Log("Duration (s): " + duration);

        direction = differenceVectorAB.normalized;
        Debug.Log("Initial Direction: " + direction);
    }

    void Update()
    {
        player.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            timer = 0f;
            fromAToB = !fromAToB;

            if (fromAToB)
            {
                direction = (pointB.position - pointA.position).normalized;
                Debug.Log("Switching direction: A to B");
            }
            else
            {
                direction = (pointA.position - pointB.position).normalized;
                Debug.Log("Switching direction: B to A");
            }
        }
    }
}