using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public float movingSpeed = 5.0f;

    public float maxOffset = 8.0f;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (!player)
            return;
    }


    void Update()
    {
        var p = player.position;
        var mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p += Vector3.ClampMagnitude(mp - p, maxOffset);
        p.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, p, movingSpeed * Time.deltaTime);
    }
}
