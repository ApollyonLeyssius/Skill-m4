using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceball : MonoBehaviour
{
    Vector3 direction = new Vector3(1, 2, 0);
    float speed = 3;
    Vector2 min, max;
    Vector3 velocity;
    void Start()
    {
        // Normaliseer de richtingsvector
        direction = direction.normalized;
        // Converteer schermhoeken naar wereldcoördinaten
        min = Camera.main.ScreenToWorldPoint(Vector2.zero); max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        // Bereken snelheid
        velocity = direction * speed * Time.deltaTime;

        // Verplaats de bal
        transform.position += velocity;

        if (transform.position.x + transform.localScale.x / 2 > max.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.x - transform.localScale.x / 2 < min.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y + transform.localScale.y / 2 > max.y)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y - transform.localScale.y / 2 < min.y)
        {
            direction.y = -direction.y;
        }
    }
}
