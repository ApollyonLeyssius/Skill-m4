using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = new Vector3(1, 0, 0);
    float speed;

    void Start()
    {
        speed = 15.0f;
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Enemy geraakt!");
            Destroy(other.gameObject); // Verwijder de tank
            Destroy(this.gameObject);  // Verwijder de kogel
        }
    }

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
}