using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;   

    public float speed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }
}
