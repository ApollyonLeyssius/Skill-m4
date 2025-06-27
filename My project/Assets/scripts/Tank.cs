using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensure the Bullet class is defined and inherits from MonoBehaviour
public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    void Update()
    {
        // Move the bullet in the specified direction
        transform.position += Direction * Time.deltaTime * 10f;
    }
}

public class Tank : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // Renamed 'bullet' to 'bulletPrefab' for clarity
    Vector3 velocity;
    Vector3 direction;
    float speed;
    float horizontal = 0;
    float vertical = 0;
    Vector2 maxScreen, minScreen;

    void Start()
    {
        direction = transform.right;
        speed = 1.0f;

        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        horizontal = -Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, horizontal);

        vertical = Input.GetAxis("Vertical");
        speed += vertical * 0.3f;
        speed = Mathf.Clamp(speed, 0f, 10.0f);

        direction = transform.right;
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
        BoxingTank();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject copyOfBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            if (copyOfBullet.TryGetComponent(out Bullet bulletComponent)) // Use TryGetComponent to avoid allocation
            {
                bulletComponent.Direction = direction; // Set direction if the component exists
            }
        }
    }

    void BoxingTank()
    {
        Vector3 pos = transform.position;
        if (pos.x > maxScreen.x) { pos.x = minScreen.x; }
        if (pos.x < minScreen.x) { pos.x = maxScreen.x; }
        if (pos.y > maxScreen.y) { pos.y = minScreen.y; }
        if (pos.y < minScreen.y) { pos.y = maxScreen.y; }
        transform.position = pos;
    }
}
