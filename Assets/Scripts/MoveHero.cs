using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D rigidbody;
    Rigidbody2D rigidbody;
    private float hHeroMoving;

    [SerializeField] private float speed = 5.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hHeroMoving = Input.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal"); 
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(hHeroMoving * speed, 0); //rigidbody.velocity.y);
            //.transform.Translate(hHeroMoving * speed,0); 
           
    }
}
