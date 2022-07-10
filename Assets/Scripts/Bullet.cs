using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector2 lastVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rb.velocity;
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * speed;


        
    }
}
