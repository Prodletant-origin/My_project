using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public Sprite bulletAfterRic;

    Vector2 lastVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rb.velocity;

        Destroy(gameObject, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<SpriteRenderer>().sprite = bulletAfterRic;

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * speed;

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
