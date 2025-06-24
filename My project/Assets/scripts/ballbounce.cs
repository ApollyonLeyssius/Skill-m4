using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballbounce : MonoBehaviour
{
    Vector3 velocity = new Vector3(1, 2, 0);
    Vector3 direction;
    float speed = 5f;
    Vector2 min, max;
    void Start()
    {
        direction = velocity.normalized;
        min = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
