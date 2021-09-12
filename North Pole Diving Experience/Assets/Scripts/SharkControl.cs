using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkControl : MonoBehaviour
{
    public float speed = 0.01f;
    public float startingPosition, turnaroundPosition;

    private Rigidbody2D rigidBody;
    private float movement;
    private Vector2 movementDirection = Vector2.right;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > turnaroundPosition)
        {
            movementDirection = Vector2.left;
            spriteRenderer.flipX = false;
        }
        else if(transform.position.x < startingPosition)
        {
            movementDirection = Vector2.right;
            spriteRenderer.flipX = true;
        }

        transform.Translate(movementDirection * Time.deltaTime * speed);
    }
}
