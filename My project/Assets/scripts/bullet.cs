using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = new Vector3(1, 0, 0);
    float speed;




    void Start()
    {
        speed = 15.0f;
        Destroy(gameObject, 2);

    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;

    }

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

}
